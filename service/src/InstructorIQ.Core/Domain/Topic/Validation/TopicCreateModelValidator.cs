using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="TopicCreateModel"/> .
    /// </summary>
    public class TopicCreateModelValidator
        : AbstractValidator<TopicCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopicCreateModelValidator"/> class.
        /// </summary>
        public TopicCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Title).MaximumLength(256);
            RuleFor(p => p.Summary).MaximumLength(256);
            #endregion
        }

    }
}
