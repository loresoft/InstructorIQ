using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class SessionGroupCreateModelValidator : AbstractValidator<SessionGroupCreateModel>
    {
        public SessionGroupCreateModelValidator()
        {
        }
    }
}