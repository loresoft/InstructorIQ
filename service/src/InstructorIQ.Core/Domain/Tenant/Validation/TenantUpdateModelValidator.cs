using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="TenantUpdateModel"/> .
    /// </summary>
    public partial class TenantUpdateModelValidator
        : AbstractValidator<TenantUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantUpdateModelValidator"/> class.
        /// </summary>
        public TenantUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(256);
            RuleFor(p => p.Abbreviation).NotEmpty();
            RuleFor(p => p.Abbreviation).MaximumLength(50);
            RuleFor(p => p.City).MaximumLength(150);
            RuleFor(p => p.StateProvince).MaximumLength(150);
            RuleFor(p => p.TimeZone).NotEmpty();
            RuleFor(p => p.TimeZone).MaximumLength(150);
            #endregion
        }

    }
}
