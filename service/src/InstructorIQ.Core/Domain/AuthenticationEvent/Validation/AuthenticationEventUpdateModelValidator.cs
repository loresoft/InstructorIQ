using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="AuthenticationEventUpdateModel"/> .
    /// </summary>
    public partial class AuthenticationEventUpdateModelValidator
        : AbstractValidator<AuthenticationEventUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationEventUpdateModelValidator"/> class.
        /// </summary>
        public AuthenticationEventUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).MaximumLength(256);
            RuleFor(p => p.UserName).NotEmpty();
            RuleFor(p => p.UserName).MaximumLength(256);
            RuleFor(p => p.Browser).MaximumLength(256);
            RuleFor(p => p.OperatingSystem).MaximumLength(256);
            RuleFor(p => p.DeviceFamily).MaximumLength(256);
            RuleFor(p => p.DeviceBrand).MaximumLength(256);
            RuleFor(p => p.DeviceModel).MaximumLength(256);
            RuleFor(p => p.IpAddress).MaximumLength(50);
            RuleFor(p => p.FailureMessage).MaximumLength(256);
            #endregion
        }

    }
}
