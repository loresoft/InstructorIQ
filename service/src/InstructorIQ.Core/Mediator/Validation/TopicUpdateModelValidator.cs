using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class TopicUpdateModelValidator : AbstractValidator<TopicUpdateModel>
    {
        public TopicUpdateModelValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
        }
    }
}