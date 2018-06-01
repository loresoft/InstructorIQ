using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class HistoryRecordUpdateModelValidator : AbstractValidator<HistoryRecordUpdateModel>
    {
        public HistoryRecordUpdateModelValidator()
        {
            RuleFor(p => p.Entity).NotEmpty();
        }
    }
}