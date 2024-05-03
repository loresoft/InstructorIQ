using InstructorIQ.Core.Models;

namespace InstructorIQ.Core.Services;

public interface IEmailTemplateService
{
    Task<bool> SendResetPasswordEmail(UserResetPasswordEmail resetPassword);
    Task<bool> SendPasswordlessLoginEmail(UserPasswordlessEmail loginEmail);
    Task<bool> SendUserInviteEmail(UserInviteEmail inviteEmail);
    Task<bool> SendSummaryEmail(SummaryReportEmail summaryEmail);
    Task<bool> SendUserLinkEmail(UserLinkEmail userLinkModel);

    Task SendTemplate<TModel>(IEmailTemplate emailTemplate, TModel emailModel)
        where TModel : IEmailRecipient;

    Task<IEmailTemplate> GetEmailTemplate(string templateKey);
    Task<IEmailTemplate> GetDatabaseTemplate(string templateKey);
    IEmailTemplate GetResourceTemplate(string templateKey);

    string ApplyTemplate<TModel>(string handlebarTemplate, TModel model);
}
