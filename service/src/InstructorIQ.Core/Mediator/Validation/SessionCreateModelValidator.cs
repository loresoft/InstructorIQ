using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class SessionCreateModelValidator : AbstractValidator<SessionCreateModel>
    {
        public SessionCreateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}