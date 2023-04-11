using System;

using FluentValidation;

using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation;

/// <summary>
/// Validator class for <see cref="SessionCreateModel"/> .
/// </summary>
public class SessionCreateModelValidator
    : AbstractValidator<SessionCreateModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SessionCreateModelValidator"/> class.
    /// </summary>
    public SessionCreateModelValidator()
    {
        #region Generated Constructor
        #endregion
    }

}
