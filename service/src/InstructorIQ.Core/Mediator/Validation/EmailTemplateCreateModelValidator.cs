using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
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