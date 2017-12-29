using System;
using System.Threading.Tasks;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Services
{
    public interface IEmailTemplateService
    {
        Task<bool> SendResetPasswordEmail(UserResetPasswordEmail resetPassword);
    }
}