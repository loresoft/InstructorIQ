using System;

namespace InstructorIQ.Core.Mediator.Models
{
    public class UserRegisterModel
    {
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

    public class UserForgotPasswordModel
    {
        public string EmailAddress { get; set; }
    }

    public class UserResetPasswordModel
    {
        public string EmailAddress { get; set; }
        public string SecurityToken { get; set; }
        public string UpdatedPassword { get; set; }
    }

    public class UserChangePasswordModel
    {
        public string CurrentPassword { get; set; }

        public string UpdatedPassword { get; set; }
    }
}