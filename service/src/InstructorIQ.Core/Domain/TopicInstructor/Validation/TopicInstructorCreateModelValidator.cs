using System;

using FluentValidation;

using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation;

/// <summary>
/// Validator class for <see cref="TopicInstructorCreateModel"/> .
/// </summary>
public partial class TopicInstructorCreateModelValidator
    : AbstractValidator<TopicInstructorCreateModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TopicInstructorCreateModelValidator"/> class.
    /// </summary>
    public TopicInstructorCreateModelValidator()
    {
        #region Generated Constructor
        #endregion
    }

}
