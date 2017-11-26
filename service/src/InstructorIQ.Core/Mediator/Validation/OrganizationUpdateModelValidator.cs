using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class OrganizationUpdateModelValidator : AbstractValidator<OrganizationUpdateModel>
    {
        public OrganizationUpdateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Abbreviation).NotEmpty();
        }
    }
}