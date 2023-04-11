using System;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Security;
using InstructorIQ.Core.Services;

using MediatR;
using MediatR.CommandQuery.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers;

public class SendUserInviteEmailCommandHandler : EmailTemplateCommandHandlerBase<SendUserInviteEmailCommand, CompleteModel>
{
    private readonly UserManager<User> _userManager;
    private readonly UserClaimManager _userClaimManager;
    private readonly IUrlHelper _urlHelper;

    public SendUserInviteEmailCommandHandler(ILoggerFactory loggerFactory, IMediator mediator, IEmailTemplateService emailTemplate, UserManager<User> userManager, UserClaimManager userClaimManager, IUrlHelper urlHelper)
        : base(loggerFactory, mediator, emailTemplate)
    {
        _userManager = userManager;
        _userClaimManager = userClaimManager;
        _urlHelper = urlHelper;
    }

    protected override async Task<CompleteModel> Process(SendUserInviteEmailCommand request, CancellationToken cancellationToken)
    {
        var completeModel = new CompleteModel();
        var inviteModel = request.Model;
        var principal = request.Principal;
        var returnUrl = inviteModel.ReturnUrl;

        // lookup user
        var recipientUser = inviteModel.User;
        if (recipientUser == null)
            throw new InvalidOperationException("Recipient not found, can't send email");

        // create user token
        var token = _userManager.GenerateNewAuthenticatorKey();
        await CreateLinkToken(recipientUser, token, returnUrl, principal);
        var link = CreateLink(token);

        await SendInvite(inviteModel, recipientUser, principal, link);

        return completeModel;
    }

    private async Task SendInvite(UserInviteModel inviteModel, User recipientUser, IPrincipal principal, string link)
    {
        var name = _userClaimManager.GetDisplayName(principal);
        var email = _userClaimManager.GetEmail(principal);

        var inviteEmail = new UserInviteEmail
        {
            TenantName = _userClaimManager.GetTenantName(principal),

            SenderName = name,
            SenderEmail = email,

            ReplyToName = name,
            ReplyToAddress = email,

            RecipientName = recipientUser.DisplayName,
            RecipientAddress = recipientUser.Email,

            Link = link,

            UserAgent = inviteModel.UserAgent,
            Browser = inviteModel.Browser,
            OperatingSystem = inviteModel.OperatingSystem,
            DeviceFamily = inviteModel.DeviceFamily,
            DeviceBrand = inviteModel.DeviceBrand,
            DeviceModel = inviteModel.DeviceModel,
            IpAddress = inviteModel.IpAddress
        };

        Logger.LogInformation("Sending user invite email to '{recipient}'", recipientUser.Email);

        await EmailTemplate.SendUserInviteEmail(inviteEmail);
    }

    private string CreateLink(string token)
    {
        var scheme = _urlHelper.ActionContext?.HttpContext?.Request?.Scheme ?? "http";

        // create link to send in email
        var emailLink = _urlHelper.Page(
            "/Account/Link",
            pageHandler: null,
            values: new { token },
            protocol: scheme);

        return emailLink;
    }

    private async Task CreateLinkToken(User user, string token, string returnUrl, IPrincipal principal)
    {
        var createModel = new LinkTokenCreateModel
        {
            Expires = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(30)),
            Url = returnUrl,
            UserName = user.UserName,
            TenantId = _userClaimManager.GetTenantId(principal),
        };

        var createCommand = new LinkTokenCreateCommand(principal, createModel, token);
        var linkToken = await Mediator.Send(createCommand);
    }
}
