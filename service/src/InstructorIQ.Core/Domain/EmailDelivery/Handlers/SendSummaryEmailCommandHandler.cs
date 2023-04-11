using System.Threading;
using System.Threading.Tasks;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Services;

using MediatR;
using MediatR.CommandQuery.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers;

public class SendSummaryEmailCommandHandler : EmailTemplateCommandHandlerBase<SendSummaryEmailCommand, CompleteModel>
{
    private readonly UserManager<Core.Data.Entities.User> _userManager;

    public SendSummaryEmailCommandHandler(ILoggerFactory loggerFactory, IMediator mediator, IEmailTemplateService emailTemplate, UserManager<User> userManager)
        : base(loggerFactory, mediator, emailTemplate)
    {
        _userManager = userManager;
    }

    protected override async Task<CompleteModel> Process(SendSummaryEmailCommand request, CancellationToken cancellationToken)
    {
        foreach (var recipient in request.Model.Recipients)
            await SendSummaryEmail(request.Model, recipient);

        var completeModel = new CompleteModel();
        return completeModel;
    }

    private async Task SendSummaryEmail(SummaryReportModel userLinkModel, string recipient)
    {
        // lookup user
        var recipientUser = await _userManager.FindByEmailAsync(recipient);
        if (recipientUser == null)
        {
            Logger.LogError("Recipient '{recipient}' not found, can't send email", recipient);
            return;
        }

        // create email model
        var email = new SummaryReportEmail()
        {
            RecipientName = recipientUser.DisplayName,
            RecipientAddress = recipientUser.Email,
            ReplyToName = userLinkModel.ReplyToName,
            ReplyToAddress = userLinkModel.ReplyToAddress,
            Subject = userLinkModel.Subject,
            TextBody = userLinkModel.TextBody,
            HtmlBody = userLinkModel.HtmlBody
        };

        Logger.LogInformation("Sending user link email to '{recipient}'", recipient);

        await EmailTemplate.SendSummaryEmail(email).ConfigureAwait(false);
    }
}
