using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class LocationCreateModelValidator : AbstractValidator<LocationCreateModel>
    {
        public LocationCreateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}