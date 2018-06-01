using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class InstructorUpdateModelValidator : AbstractValidator<InstructorUpdateModel>
    {
        public InstructorUpdateModelValidator()
        {
            RuleFor(p => p.GivenName).NotEmpty();
            RuleFor(p => p.FamilyName).NotEmpty();
            RuleFor(p => p.DisplayName).NotEmpty();
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.MobilePhone).NotEmpty();
        }
    }
}