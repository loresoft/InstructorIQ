using System;

using FluentValidation;

using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation;

/// <summary>
/// Validator class for <see cref="NotificationUpdateModel"/> .
/// </summary>
public partial class NotificationUpdateModelValidator
    : AbstractValidator<NotificationUpdateModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationUpdateModelValidator"/> class.
    /// </summary>
    public NotificationUpdateModelValidator()
    {
        #region Generated Constructor
        RuleFor(p => p.Type).NotEmpty();
        RuleFor(p => p.Type).MaximumLength(256);
        RuleFor(p => p.UserName).NotEmpty();
        RuleFor(p => p.UserName).MaximumLength(256);
        #endregion
    }

}
