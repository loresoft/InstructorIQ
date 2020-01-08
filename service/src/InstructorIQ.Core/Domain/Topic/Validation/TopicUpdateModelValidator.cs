using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="TopicUpdateModel"/> .
    /// </summary>
    public class TopicUpdateModelValidator
        : AbstractValidator<TopicUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopicUpdateModelValidator"/> class.
        /// </summary>
        public TopicUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Title).MaximumLength(256);
            RuleFor(p => p.Summary).MaximumLength(256);
            #endregion
        }

    }
}
