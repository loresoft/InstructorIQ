using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="UserUpdateModel"/> .
    /// </summary>
    public class UserUpdateModelValidator
        : AbstractValidator<UserUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserUpdateModelValidator"/> class.
        /// </summary>
        public UserUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).MaximumLength(256);
            RuleFor(p => p.DisplayName).NotEmpty();
            RuleFor(p => p.DisplayName).MaximumLength(256);
            #endregion
			
			RuleFor(p => p.EmailAddress).EmailAddress();
        }

    }
}
