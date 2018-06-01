using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
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