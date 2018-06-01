using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class TopicCreateModelValidator : AbstractValidator<TopicCreateModel>
    {
        public TopicCreateModelValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
        }
    }
}