using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="InstructorUpdateModel"/> .
    /// </summary>
    public class InstructorUpdateModelValidator
        : AbstractValidator<InstructorUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstructorUpdateModelValidator"/> class.
        /// </summary>
        public InstructorUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.GivenName).MaximumLength(256);
            RuleFor(p => p.MiddleName).MaximumLength(256);
            RuleFor(p => p.FamilyName).MaximumLength(256);
            RuleFor(p => p.DisplayName).NotEmpty();
            RuleFor(p => p.DisplayName).MaximumLength(256);
            RuleFor(p => p.JobTitle).MaximumLength(256);
            RuleFor(p => p.EmailAddress).MaximumLength(256);
            RuleFor(p => p.MobilePhone).MaximumLength(50);
            RuleFor(p => p.BusinessPhone).MaximumLength(50);
            #endregion
        }

    }
}
