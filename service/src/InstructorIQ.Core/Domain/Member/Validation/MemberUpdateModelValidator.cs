using FluentValidation;

using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation;

public class MemberUpdateModelValidator
    : AbstractValidator<MemberUpdateModel>
{
    public MemberUpdateModelValidator()
    {
        RuleFor(p => p.DisplayName).NotEmpty();
        RuleFor(p => p.DisplayName).MaximumLength(256);
        RuleFor(p => p.Email).NotEmpty();
        RuleFor(p => p.Email).MaximumLength(256);
    }
}
