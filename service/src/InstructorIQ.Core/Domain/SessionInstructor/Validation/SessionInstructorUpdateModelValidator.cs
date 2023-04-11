using System;

using FluentValidation;

using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation;

/// <summary>
/// Validator class for <see cref="SessionInstructorUpdateModel"/> .
/// </summary>
public partial class SessionInstructorUpdateModelValidator
    : AbstractValidator<SessionInstructorUpdateModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SessionInstructorUpdateModelValidator"/> class.
    /// </summary>
    public SessionInstructorUpdateModelValidator()
    {
        #region Generated Constructor
        #endregion
    }

}
