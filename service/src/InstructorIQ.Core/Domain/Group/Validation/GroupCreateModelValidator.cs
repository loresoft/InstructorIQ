using System;

using FluentValidation;

using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation;

/// <summary>
/// Validator class for <see cref="GroupCreateModel"/> .
/// </summary>
public class GroupCreateModelValidator
    : AbstractValidator<GroupCreateModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GroupCreateModelValidator"/> class.
    /// </summary>
    public GroupCreateModelValidator()
    {
        #region Generated Constructor
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Name).MaximumLength(256);
        #endregion
    }

}
