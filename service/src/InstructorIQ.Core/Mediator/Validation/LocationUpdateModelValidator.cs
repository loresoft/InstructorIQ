using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class LocationUpdateModelValidator : AbstractValidator<LocationUpdateModel>
    {
        public LocationUpdateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}