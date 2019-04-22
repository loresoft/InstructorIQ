using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="DiscussionUpdateModel"/> .
    /// </summary>
    public partial class DiscussionUpdateModelValidator
        : AbstractValidator<DiscussionUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscussionUpdateModelValidator"/> class.
        /// </summary>
        public DiscussionUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).MaximumLength(256);
            RuleFor(p => p.DisplayName).NotEmpty();
            RuleFor(p => p.DisplayName).MaximumLength(256);
            RuleFor(p => p.Browser).MaximumLength(256);
            RuleFor(p => p.OperatingSystem).MaximumLength(256);
            RuleFor(p => p.DeviceFamily).MaximumLength(256);
            RuleFor(p => p.DeviceBrand).MaximumLength(256);
            RuleFor(p => p.DeviceModel).MaximumLength(256);
            RuleFor(p => p.IpAddress).MaximumLength(50);
            #endregion
        }

    }
}
