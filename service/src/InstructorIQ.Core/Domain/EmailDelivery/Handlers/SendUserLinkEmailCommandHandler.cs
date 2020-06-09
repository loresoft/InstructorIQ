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
namespace InstructorIQ.Core.Domain.Handlers
{
    public class SendUserLinkEmailCommandHandler : EmailTemplateCommandHandlerBase<SendUserLinkEmailCommand, CompleteModel>
    {
        private readonly UserManager<Core.Data.Entities.User> _userManager;
        private readonly UserClaimManager _userClaimManager;
        private readonly IUrlHelper _urlHelper;

        public SendUserLinkEmailCommandHandler(ILoggerFactory loggerFactory, IMediator mediator, IEmailTemplateService emailTemplate, UserManager<User> userManager, IUrlHelper urlHelper, UserClaimManager userClaimManager)
            : base(loggerFactory, mediator, emailTemplate)
        {
            _userManager = userManager;
            _urlHelper = urlHelper;
            _userClaimManager = userClaimManager;
        }

        protected override async Task<CompleteModel> Process(SendUserLinkEmailCommand request, CancellationToken cancellationToken)
        {
            foreach (var recipient in request.Model.Recipients)
            {
                // create passwordless link for each recipient
                await SendRecipientLinkEmail(request.Model, request.Principal, recipient, cancellationToken);
            }

            var completeModel = new CompleteModel();
            return completeModel;
        }

        private async Task SendRecipientLinkEmail(UserLinkModel userLinkModel, IPrincipal principal, string recipient, CancellationToken cancellationToken)
        {
            // lookup user
            var recipientUser = await _userManager.FindByEmailAsync(recipient);
            if (recipientUser == null)
            {
                Logger.LogError("Recipient '{recipient}' not found, can't send email", recipient);
                return;
            }

            // create user link
            var createModel = new LinkTokenCreateModel
            {
                Expires = DateTimeOffset.UtcNow.AddMonths(1),
                Url = userLinkModel.LinkUrl,
                UserName = recipientUser.UserName,
                TenantId = _userClaimManager.GetTenantId(principal)
            };

            // create user token
            var token = _userManager.GenerateNewAuthenticatorKey();
            var createCommand = new LinkTokenCreateCommand(principal, createModel, token);
            var linkToken = await Mediator.Send(createCommand, cancellationToken).ConfigureAwait(false);

            var scheme = _urlHelper.ActionContext?.HttpContext?.Request?.Scheme ?? "http";

            // create link to send in email
            var emailLink = _urlHelper.Page(
                "/Account/Link",
                pageHandler: null,
                values: new { token },
                protocol: scheme);

            // create email model
            var email = new UserLinkEmail
            {
                RecipientName = recipientUser.DisplayName,
                RecipientAddress = recipientUser.Email,
                ReplyToName = userLinkModel.ReplyToName,
                ReplyToAddress = userLinkModel.ReplyToAddress,
                Subject = userLinkModel.Subject,
                TextBody = userLinkModel.TextBody,
                HtmlBody = userLinkModel.HtmlBody,
                LinkUrl = emailLink,
                LinkText = userLinkModel.LinkText
            };

            Logger.LogInformation("Sending user link email to '{recipient}'", recipient);

            await EmailTemplate.SendUserLinkEmail(email).ConfigureAwait(false);
        }
    }
}
