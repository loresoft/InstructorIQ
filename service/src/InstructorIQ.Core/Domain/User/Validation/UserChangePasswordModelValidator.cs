using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
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