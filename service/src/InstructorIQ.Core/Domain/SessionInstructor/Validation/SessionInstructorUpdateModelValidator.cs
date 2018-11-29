using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="SessionInstructorUpdateModel"/> .
    /// </summary>
    public class SessionInstructorUpdateModelValidator
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
}
