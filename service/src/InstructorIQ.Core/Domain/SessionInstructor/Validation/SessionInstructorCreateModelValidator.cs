using System;

using FluentValidation;

using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation;

/// <summary>
/// Validator class for <see cref="SessionInstructorCreateModel"/> .
/// </summary>
public partial class SessionInstructorCreateModelValidator
    : AbstractValidator<SessionInstructorCreateModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SessionInstructorCreateModelValidator"/> class.
    /// </summary>
    public SessionInstructorCreateModelValidator()
    {
        #region Generated Constructor
        #endregion
    }

}
