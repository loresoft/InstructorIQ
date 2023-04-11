using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using HandlebarsDotNet;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Data.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Options;

using MediatR.CommandQuery;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using MimeKit;

using SendGrid;
using SendGrid.Helpers.Mail;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace InstructorIQ.Core.Services;

public class EmailTemplateService : IEmailTemplateService
{
    private readonly InstructorIQContext _dataContext;
    private readonly IMemoryCache _cache;
    private readonly IOptions<SendGridConfiguration> _sendGridOptions;
    private readonly IHtmlService _htmlService;
    private readonly ILogger<EmailTemplateService> _logger;
    private readonly ISendGridClient _sendGridClient;

    public EmailTemplateService(InstructorIQContext dataContext, IMemoryCache cache, IOptions<SendGridConfiguration> sendGridOptions, IHtmlService htmlService, ILogger<EmailTemplateService> logger, ISendGridClient sendGridClient)
    {
        _dataContext = dataContext;
        _cache = cache;
        _sendGridOptions = sendGridOptions;
        _htmlService = htmlService;
        _logger = logger;
        _sendGridClient = sendGridClient;
    }


    public async Task<bool> SendResetPasswordEmail(UserResetPasswordEmail resetPassword)
    {
        var emailTemplate = await GetEmailTemplate(Templates.ResetPassword).ConfigureAwait(false);

        await SendTemplate(emailTemplate, resetPassword).ConfigureAwait(false);

        return true;
    }

    public async Task<bool> SendPasswordlessLoginEmail(UserPasswordlessEmail loginEmail)
    {
        var emailTemplate = await GetEmailTemplate(Templates.PasswordlessLogin).ConfigureAwait(false);

        await SendTemplate(emailTemplate, loginEmail).ConfigureAwait(false);

        return true;
    }

    public async Task<bool> SendUserInviteEmail(UserInviteEmail inviteEmail)
    {
        var emailTemplate = await GetEmailTemplate(Templates.UserInvite).ConfigureAwait(false);

        // use model reply to address
        emailTemplate.ReplyToAddress = inviteEmail.ReplyToAddress;
        emailTemplate.ReplyToName = inviteEmail.ReplyToName;

        await SendTemplate(emailTemplate, inviteEmail).ConfigureAwait(false);

        return true;
    }

    public async Task<bool> SendSummaryEmail(SummaryReportEmail summaryEmail)
    {
        var emailTemplate = await GetEmailTemplate(Templates.SummaryReport).ConfigureAwait(false);

        // use model reply to address
        emailTemplate.ReplyToAddress = summaryEmail.ReplyToAddress;
        emailTemplate.ReplyToName = summaryEmail.ReplyToName;

        await SendTemplate(emailTemplate, summaryEmail).ConfigureAwait(false);

        return true;
    }

    public async Task<bool> SendUserLinkEmail(UserLinkEmail userLinkModel)
    {
        var emailTemplate = await GetEmailTemplate(Templates.UserLink).ConfigureAwait(false);

        // use model reply to address
        emailTemplate.ReplyToAddress = userLinkModel.ReplyToAddress;
        emailTemplate.ReplyToName = userLinkModel.ReplyToName;

        await SendTemplate(emailTemplate, userLinkModel).ConfigureAwait(false);

        return true;
    }


    public async Task SendTemplate<TModel>(IEmailTemplate emailTemplate, TModel emailModel)
        where TModel : IEmailRecipient
    {
        if (emailTemplate == null)
            throw new ArgumentNullException(nameof(emailTemplate));

        if (emailModel == null)
            throw new ArgumentNullException(nameof(emailModel));

        try
        {
            var subject = ApplyTemplate(emailTemplate.Subject, emailModel);
            var htmlBody = ApplyTemplate(emailTemplate.HtmlBody, emailModel);
            var textBody = ApplyTemplate(emailTemplate.TextBody, emailModel);

            // ensure text body has value
            if (textBody.IsNullOrWhiteSpace() && htmlBody.HasValue())
                textBody = _htmlService.PlainText(htmlBody);

            var message = new SendGridMessage();
            message.Subject = subject;

            // first try reply to name, next try model from address, default to option address
            var fromName = emailTemplate.ReplyToName.HasValue()
                ? emailTemplate.ReplyToName
                : emailTemplate.FromName.HasValue()
                    ? emailTemplate.FromName
                    : _sendGridOptions.Value.FromName;

            var fromEmail = emailTemplate.FromAddress.HasValue()
                ? emailTemplate.FromAddress
                : _sendGridOptions.Value.FromEmail;

            message.From = new EmailAddress(fromEmail, fromName);

            if (emailTemplate.ReplyToAddress.HasValue())
                message.ReplyTo = new EmailAddress(emailTemplate.ReplyToAddress, emailTemplate.ReplyToName);

            message.AddTo(new EmailAddress(emailModel.RecipientAddress, emailModel.RecipientName));

            message.PlainTextContent = textBody;
            message.HtmlContent = htmlBody;

            _logger.LogInformation("Sending Email To: {email}, Subject: {subject} ...", emailModel.RecipientAddress, subject);

            var response = await _sendGridClient.SendEmailAsync(message).ConfigureAwait(false);

            _logger.LogInformation("Sent Email To: {email}, Subject: {subject}: Status Code: {statusCode}", emailModel.RecipientAddress, subject, response.StatusCode);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Sending Email To: {email}; {message}", emailModel.RecipientAddress, ex.Message);
            throw;
        }
    }


    public string ApplyTemplate<TModel>(string handlebarTemplate, TModel model)
    {
        if (handlebarTemplate.IsNullOrWhiteSpace())
            return string.Empty;

        var compiledTemplate = Handlebars.Compile(handlebarTemplate);
        return compiledTemplate(model);
    }

    public async Task<IEmailTemplate> GetEmailTemplate(string templateKey)
    {
        var cacheKey = "data-" + templateKey;
        var emailTemplate = await _cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.Priority = CacheItemPriority.NeverRemove;

            var template = await GetDatabaseTemplate(templateKey);
            if (template == null)
                template = GetResourceTemplate(templateKey);

            return template;
        }).ConfigureAwait(false);

        if (emailTemplate == null)
            throw new DomainException(500, $"Could not find email template for key '{templateKey}'.");

        return emailTemplate;
    }

    public async Task<IEmailTemplate> GetDatabaseTemplate(string templateKey)
    {
        var template = await _dataContext.EmailTemplates
            .AsNoTracking()
            .GetByKeyAsync(templateKey)
            .ConfigureAwait(false);

        return template;
    }

    public IEmailTemplate GetResourceTemplate(string templateKey)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = $"InstructorIQ.Core.Templates.{templateKey}.yml";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
            return null;

        using var reader = new StreamReader(stream);
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        return deserializer.Deserialize<EmailTemplate>(reader);
    }


    public static class Templates
    {
        public const string ResetPassword = "reset-password";
        public const string PasswordlessLogin = "passwordless-login";
        public const string UserInvite = "user-invite";
        public const string SummaryReport = "summary-report";
        public const string UserLink = "user-link";
    }
}
