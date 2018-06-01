using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.User.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
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
}