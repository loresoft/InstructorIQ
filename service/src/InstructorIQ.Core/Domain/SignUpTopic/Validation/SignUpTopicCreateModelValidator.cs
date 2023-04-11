using System;

using FluentValidation;

using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation;

/// <summary>
/// Validator class for <see cref="SignUpTopicCreateModel"/> .
/// </summary>
public partial class SignUpTopicCreateModelValidator
    : AbstractValidator<SignUpTopicCreateModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SignUpTopicCreateModelValidator"/> class.
    /// </summary>
    public SignUpTopicCreateModelValidator()
    {
        #region Generated Constructor
        #endregion
    }

}
