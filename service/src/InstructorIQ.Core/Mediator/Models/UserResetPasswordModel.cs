using System;

namespace InstructorIQ.Core.Mediator.Models
{
    public class UserResetPasswordModel
    {
        public string EmailAddress { get; set; }
        public string ResetToken { get; set; }
        public string UpdatedPassword { get; set; }
    }
}