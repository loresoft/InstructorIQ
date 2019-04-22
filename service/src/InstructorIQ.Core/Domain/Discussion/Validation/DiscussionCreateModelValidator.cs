using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="DiscussionCreateModel"/> .
    /// </summary>
    public partial class DiscussionCreateModelValidator
        : AbstractValidator<DiscussionCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscussionCreateModelValidator"/> class.
        /// </summary>
        public DiscussionCreateModelValidator()
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
