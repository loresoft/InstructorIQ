using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class HistoryRecordCreateModelValidator : AbstractValidator<HistoryRecordCreateModel>
    {
        public HistoryRecordCreateModelValidator()
        {
            RuleFor(p => p.Entity).NotEmpty();
        }
    }
}