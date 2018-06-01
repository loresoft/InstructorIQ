using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class LocationUpdateModelValidator : AbstractValidator<LocationUpdateModel>
    {
        public LocationUpdateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}