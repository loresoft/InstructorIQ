using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class SessionCreateModelValidator : AbstractValidator<SessionCreateModel>
    {
        public SessionCreateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}