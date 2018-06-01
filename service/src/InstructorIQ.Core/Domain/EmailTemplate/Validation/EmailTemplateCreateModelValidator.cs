using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class EmailTemplateCreateModelValidator : AbstractValidator<EmailTemplateCreateModel>
    {
        public EmailTemplateCreateModelValidator()
        {
            RuleFor(p => p.Key).NotEmpty();
            RuleFor(p => p.FromAddress).NotEmpty();
            RuleFor(p => p.FromName).NotEmpty();
        }
    }
}