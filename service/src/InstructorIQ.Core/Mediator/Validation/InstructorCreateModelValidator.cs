using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class InstructorCreateModelValidator : AbstractValidator<InstructorCreateModel>
    {
        public InstructorCreateModelValidator()
        {
            RuleFor(p => p.GivenName).NotEmpty();
            RuleFor(p => p.FamilyName).NotEmpty();
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.MobilePhone).NotEmpty();
        }
    }
}