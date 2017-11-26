using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class InstructorUpdateModelValidator : AbstractValidator<InstructorUpdateModel>
    {
        public InstructorUpdateModelValidator()
        {
            RuleFor(p => p.GivenName).NotEmpty();
            RuleFor(p => p.FamilyName).NotEmpty();
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.MobilePhone).NotEmpty();
        }
    }
}