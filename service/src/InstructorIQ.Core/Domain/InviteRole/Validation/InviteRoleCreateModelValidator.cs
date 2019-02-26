using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="InviteRoleCreateModel"/> .
    /// </summary>
    public partial class InviteRoleCreateModelValidator
        : AbstractValidator<InviteRoleCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InviteRoleCreateModelValidator"/> class.
        /// </summary>
        public InviteRoleCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.RoleName).NotEmpty();
            RuleFor(p => p.RoleName).MaximumLength(256);
            #endregion
        }

    }
}
