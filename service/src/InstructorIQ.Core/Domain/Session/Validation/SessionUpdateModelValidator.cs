using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class SessionUpdateModelValidator : AbstractValidator<SessionUpdateModel>
    {
        public SessionUpdateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}