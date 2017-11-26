using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class UserLoginCreateModelValidator : AbstractValidator<UserLoginCreateModel>
    {
        public UserLoginCreateModelValidator()
        {
            RuleFor(p => p.LoginProvider).NotEmpty();
            RuleFor(p => p.ProviderKey).NotEmpty();
        }
    }
}