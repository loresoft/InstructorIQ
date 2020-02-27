using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="AttendanceCreateModel"/> .
    /// </summary>
    public partial class AttendanceCreateModelValidator
        : AbstractValidator<AttendanceCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttendanceCreateModelValidator"/> class.
        /// </summary>
        public AttendanceCreateModelValidator()
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
