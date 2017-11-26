using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class UserLoginUpdateModelValidator : AbstractValidator<UserLoginUpdateModel>
    {
        public UserLoginUpdateModelValidator()
        {
            RuleFor(p => p.LoginProvider).NotEmpty();
            RuleFor(p => p.ProviderKey).NotEmpty();
        }
    }
}