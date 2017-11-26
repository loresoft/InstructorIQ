using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class OrganizationCreateModelValidator : AbstractValidator<OrganizationCreateModel>
    {
        public OrganizationCreateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Abbreviation).NotEmpty();
        }
    }
}