using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
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