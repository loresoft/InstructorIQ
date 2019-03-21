using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="TenantCreateModel"/> .
    /// </summary>
    public partial class TenantCreateModelValidator
        : AbstractValidator<TenantCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantCreateModelValidator"/> class.
        /// </summary>
        public TenantCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(256);
            RuleFor(p => p.Slug).NotEmpty();
            RuleFor(p => p.Slug).MaximumLength(50);
            RuleFor(p => p.City).MaximumLength(150);
            RuleFor(p => p.StateProvince).MaximumLength(150);
            RuleFor(p => p.TimeZone).NotEmpty();
            RuleFor(p => p.TimeZone).MaximumLength(150);
            RuleFor(p => p.DomainName).MaximumLength(150);
            #endregion
        }

    }
}
