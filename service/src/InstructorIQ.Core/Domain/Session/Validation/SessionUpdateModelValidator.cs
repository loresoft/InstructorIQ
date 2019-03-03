using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="SessionUpdateModel"/> .
    /// </summary>
    public class SessionUpdateModelValidator
        : AbstractValidator<SessionUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionUpdateModelValidator"/> class.
        /// </summary>
        public SessionUpdateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
