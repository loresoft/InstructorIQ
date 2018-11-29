using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="SessionGroupUpdateModel"/> .
    /// </summary>
    public class SessionGroupUpdateModelValidator
        : AbstractValidator<SessionGroupUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionGroupUpdateModelValidator"/> class.
        /// </summary>
        public SessionGroupUpdateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
