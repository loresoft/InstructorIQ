using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="AttendanceUpdateModel"/> .
    /// </summary>
    public partial class AttendanceUpdateModelValidator
        : AbstractValidator<AttendanceUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttendanceUpdateModelValidator"/> class.
        /// </summary>
        public AttendanceUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.AttendeeEmail).NotEmpty();
            RuleFor(p => p.AttendeeEmail).MaximumLength(256);
            RuleFor(p => p.AttendeeName).MaximumLength(256);
            RuleFor(p => p.SignatureType).MaximumLength(256);
            #endregion
        }

    }
}
