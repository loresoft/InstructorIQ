using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="InviteCreateModel"/> .
    /// </summary>
    public partial class InviteCreateModelValidator
        : AbstractValidator<InviteCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InviteCreateModelValidator"/> class.
        /// </summary>
        public InviteCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.DisplayName).MaximumLength(256);
            RuleFor(p => p.EmailAddress).MaximumLength(256);
            #endregion
        }

    }
}
