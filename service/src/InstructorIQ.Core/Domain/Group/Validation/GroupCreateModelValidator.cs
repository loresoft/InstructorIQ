using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class GroupCreateModelValidator : AbstractValidator<GroupCreateModel>
    {
        public GroupCreateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}