using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class UserForgotPasswordModelValidator : AbstractValidator<UserForgotPasswordModel>
    {
        public UserForgotPasswordModelValidator()
        {
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).EmailAddress();
            RuleFor(p => p.EmailAddress).MaximumLength(256);
        }
    }
}