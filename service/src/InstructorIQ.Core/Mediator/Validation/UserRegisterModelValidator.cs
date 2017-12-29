using System;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class UserRegisterModelValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterModelValidator()
        {
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).EmailAddress();
            RuleFor(p => p.EmailAddress).MaximumLength(256);

            RuleFor(p => p.DisplayName).NotEmpty();
            RuleFor(p => p.DisplayName).MaximumLength(256);

            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(8);
        }
    }

    public class UserForgotPasswordModelValidator : AbstractValidator<UserForgotPasswordModel>
    {
        public UserForgotPasswordModelValidator()
        {
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).EmailAddress();
            RuleFor(p => p.EmailAddress).MaximumLength(256);
        }
    }

    public class UserResetPasswordModelValidator : AbstractValidator<UserResetPasswordModel>
    {
        public UserResetPasswordModelValidator()
        {
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).EmailAddress();
            RuleFor(p => p.EmailAddress).MaximumLength(256);

            RuleFor(p => p.ResetToken).NotEmpty();

            RuleFor(p => p.UpdatedPassword).NotEmpty();
            RuleFor(p => p.UpdatedPassword).MinimumLength(8);
        }
    }

    public class UserChangePasswordModelValidator : AbstractValidator<UserChangePasswordModel>
    {
        public UserChangePasswordModelValidator()
        {
            RuleFor(p => p.CurrentPassword).NotEmpty();

            RuleFor(p => p.UpdatedPassword).NotEmpty();
            RuleFor(p => p.UpdatedPassword).MinimumLength(8);
        }
    }
}