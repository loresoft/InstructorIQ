using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class TopicUpdateModelValidator : AbstractValidator<TopicUpdateModel>
    {
        public TopicUpdateModelValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
        }
    }
}