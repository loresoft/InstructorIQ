using FluentValidation;

using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation;

public class MemberImportJobModelValidator
    : AbstractValidator<MemberImportJobModel>
{
    public MemberImportJobModelValidator()
    {
        RuleFor(p => p.EmailMapping).NotEmpty();
    }
}
