﻿using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using HandlebarsDotNet;
using Hangfire;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Data.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Models;
using MediatR.CommandQuery;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MimeKit;
using YamlDotNet.Serialization;

namespace InstructorIQ.Core.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        private readonly InstructorIQContext _dataContext;
        private readonly IMemoryCache _cache;

        public EmailTemplateService(InstructorIQContext dataContext, IMemoryCache cache)
        {
            _dataContext = dataContext;
            _cache = cache;
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

            await SendTemplate(emailTemplate, inviteEmail).ConfigureAwait(false);

            return true;
        }


        public async Task SendTemplate<TModel>(IEmailTemplate emailTemplate, TModel emailModel)
            where TModel : EmailModelBase
        {
            var subjectTemplate = Handlebars.Compile(emailTemplate.Subject);
            var htmlBodyTemplate = Handlebars.Compile(emailTemplate.HtmlBody);
            var textBodyTemplate = Handlebars.Compile(emailTemplate.TextBody);

            var subject = subjectTemplate(emailModel);
            var htmlBody = htmlBodyTemplate(emailModel);
            var textBody = textBodyTemplate(emailModel);

            var message = new MimeMessage();
            message.Headers.Add("X-Mailer-Machine", Environment.MachineName);
            message.Headers.Add("X-Mailer-Date", DateTime.Now.ToString(CultureInfo.InvariantCulture));

            message.Subject = subject;

            message.From.Add(new MailboxAddress(emailTemplate.FromName, emailTemplate.FromAddress));

            if (emailTemplate.ReplyToAddress.HasValue())
                message.ReplyTo.Add(new MailboxAddress(emailTemplate.ReplyToName, emailTemplate.ReplyToAddress));

            message.To.Add(new MailboxAddress(emailModel.DisplayName, emailModel.EmailAddress));

            var builder = new BodyBuilder();
            builder.TextBody = textBody;
            builder.HtmlBody = htmlBody;

            message.Body = builder.ToMessageBody();

            await SendMessage(message).ConfigureAwait(false);
        }

        public async Task SendMessage(MimeMessage message)
        {
            var emailDelivery = new EmailDelivery();
            
            // for reference only
            emailDelivery.From = message.From.ToDelimitedString(";").Truncate(256);
            emailDelivery.To = message.To.ToDelimitedString(";").Truncate(256);
            emailDelivery.Subject = message.Subject.Truncate(256);

            using (var memoryStream = new MemoryStream())
            {
                await message.WriteToAsync(memoryStream).ConfigureAwait(false);
                emailDelivery.MimeMessage = memoryStream.ToArray();
            }

            emailDelivery.NextAttempt = DateTimeOffset.UtcNow;

            await _dataContext.EmailDeliveries.AddAsync(emailDelivery).ConfigureAwait(false);

            await _dataContext.SaveChangesAsync().ConfigureAwait(false);

            // trigger email job
            BackgroundJob.Enqueue<IEmailDeliveryService>(emailService => 
                emailService.ProcessEmailQueueAsync(CancellationToken.None));
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

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    return null;

                using (var reader = new StreamReader(stream))
                {
                    var convention = new YamlDotNet.Serialization.NamingConventions.CamelCaseNamingConvention();
                    var deserializer = new DeserializerBuilder()
                        .WithNamingConvention(convention)
                        .Build();

                    return deserializer.Deserialize<EmailTemplate>(reader);
                }
            }

        }


        public static class Templates
        {
            public const string ResetPassword = "reset-password";
            public const string PasswordlessLogin = "passwordless-login";
            public const string UserInvite = "user-invite";
        }
    }
}
