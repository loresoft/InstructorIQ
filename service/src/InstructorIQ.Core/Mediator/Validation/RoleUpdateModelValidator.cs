using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class RoleUpdateModelValidator : AbstractValidator<RoleUpdateModel>
    {
        public RoleUpdateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}