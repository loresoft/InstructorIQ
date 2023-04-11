using System;

using FluentValidation;

using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation;

public class EmailTemplateUpdateModelValidator : AbstractValidator<EmailTemplateUpdateModel>
{
    public EmailTemplateUpdateModelValidator()
    {
        RuleFor(p => p.Key).NotEmpty();
        RuleFor(p => p.FromAddress).NotEmpty();
        RuleFor(p => p.FromName).NotEmpty();
    }
}
