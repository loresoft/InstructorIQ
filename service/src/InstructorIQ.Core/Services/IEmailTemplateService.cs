using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Models;
using MimeKit;

namespace InstructorIQ.Core.Services
{
    public interface IEmailTemplateService
    {
        Task<bool> SendResetPasswordEmail(UserResetPasswordEmail resetPassword);
        Task<bool> SendPasswordlessLoginEmail(UserPasswordlessEmail loginEmail);
        Task<bool> SendUserInviteEmail(UserInviteEmail inviteEmail);

        Task SendTemplate<TModel>(IEmailTemplate emailTemplate, TModel emailModel)
            where TModel : EmailModelBase;

        Task SendMessage(EmailMessage emailMessage);
        Task SendMessage(MimeMessage message);

        Task<IEmailTemplate> GetEmailTemplate(string templateKey);
        Task<IEmailTemplate> GetDatabaseTemplate(string templateKey);
        IEmailTemplate GetResourceTemplate(string templateKey);
    }
}