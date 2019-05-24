using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="NotificationCreateModel"/> .
    /// </summary>
    public partial class NotificationCreateModelValidator
        : AbstractValidator<NotificationCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationCreateModelValidator"/> class.
        /// </summary>
        public NotificationCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Type).NotEmpty();
            RuleFor(p => p.Type).MaximumLength(256);
            RuleFor(p => p.UserName).NotEmpty();
            RuleFor(p => p.UserName).MaximumLength(256);
            #endregion
        }

    }
}
