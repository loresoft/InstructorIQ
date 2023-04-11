using System;

using FluentValidation;

using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation;

/// <summary>
/// Validator class for <see cref="InstructorRoleUpdateModel"/> .
/// </summary>
public partial class InstructorRoleUpdateModelValidator
    : AbstractValidator<InstructorRoleUpdateModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InstructorRoleUpdateModelValidator"/> class.
    /// </summary>
    public InstructorRoleUpdateModelValidator()
    {
        #region Generated Constructor
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Name).MaximumLength(256);
        #endregion
    }

}
