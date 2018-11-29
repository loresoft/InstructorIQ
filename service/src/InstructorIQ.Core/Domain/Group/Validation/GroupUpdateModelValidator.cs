using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="GroupUpdateModel"/> .
    /// </summary>
    public class GroupUpdateModelValidator
        : AbstractValidator<GroupUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupUpdateModelValidator"/> class.
        /// </summary>
        public GroupUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(256);
            #endregion
        }

    }
}
