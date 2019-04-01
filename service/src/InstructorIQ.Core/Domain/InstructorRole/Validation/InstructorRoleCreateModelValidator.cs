using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="InstructorRoleCreateModel"/> .
    /// </summary>
    public partial class InstructorRoleCreateModelValidator
        : AbstractValidator<InstructorRoleCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstructorRoleCreateModelValidator"/> class.
        /// </summary>
        public InstructorRoleCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(256);
            #endregion
        }

    }
}
