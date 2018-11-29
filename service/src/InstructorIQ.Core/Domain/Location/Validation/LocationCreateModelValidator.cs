using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="LocationCreateModel"/> .
    /// </summary>
    public class LocationCreateModelValidator
        : AbstractValidator<LocationCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationCreateModelValidator"/> class.
        /// </summary>
        public LocationCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(256);
            RuleFor(p => p.AddressLine1).MaximumLength(256);
            RuleFor(p => p.AddressLine2).MaximumLength(256);
            RuleFor(p => p.AddressLine3).MaximumLength(256);
            RuleFor(p => p.City).MaximumLength(150);
            RuleFor(p => p.StateProvince).MaximumLength(150);
            RuleFor(p => p.PostalCode).MaximumLength(50);
            #endregion
        }

    }
}
