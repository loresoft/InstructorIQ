using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class UserUpdateModelValidator : AbstractValidator<UserUpdateModel>
    {
        public UserUpdateModelValidator()
        {
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.DisplayName).NotEmpty();
        }
    }
}