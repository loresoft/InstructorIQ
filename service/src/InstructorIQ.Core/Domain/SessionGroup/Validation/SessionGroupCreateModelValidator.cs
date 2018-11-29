using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="SessionGroupCreateModel"/> .
    /// </summary>
    public class SessionGroupCreateModelValidator
        : AbstractValidator<SessionGroupCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionGroupCreateModelValidator"/> class.
        /// </summary>
        public SessionGroupCreateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
