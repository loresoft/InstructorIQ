using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="SignUpCreateModel"/> .
    /// </summary>
    public partial class SignUpCreateModelValidator
        : AbstractValidator<SignUpCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpCreateModelValidator"/> class.
        /// </summary>
        public SignUpCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(100);
            #endregion
        }

    }
}
