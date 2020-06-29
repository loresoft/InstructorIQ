using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="SignUpUpdateModel"/> .
    /// </summary>
    public partial class SignUpUpdateModelValidator
        : AbstractValidator<SignUpUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpUpdateModelValidator"/> class.
        /// </summary>
        public SignUpUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(100);
            #endregion
        }

    }
}
