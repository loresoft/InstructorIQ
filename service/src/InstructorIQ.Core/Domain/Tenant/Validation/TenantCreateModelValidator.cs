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
            RuleFor(p => p.Abbreviation).NotEmpty();
            RuleFor(p => p.Abbreviation).MaximumLength(50);
            #endregion
        }

    }
}
