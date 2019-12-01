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
            RuleFor(p => p.AttendedBy).NotEmpty();
            RuleFor(p => p.AttendedBy).MaximumLength(256);
            RuleFor(p => p.SignatureType).MaximumLength(256);
            #endregion
        }

    }
}
