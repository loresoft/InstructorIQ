using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class GroupUpdateModelValidator : AbstractValidator<GroupUpdateModel>
    {
        public GroupUpdateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}