using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Services
{
    public interface IEmailTemplateService
    {
        Task<bool> SendResetPasswordEmail(UserResetPasswordEmail resetPassword);
    }
}