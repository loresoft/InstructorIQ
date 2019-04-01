using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="TemplateUpdateModel"/> .
    /// </summary>
    public partial class TemplateUpdateModelValidator
        : AbstractValidator<TemplateUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateUpdateModelValidator"/> class.
        /// </summary>
        public TemplateUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(100);
            RuleFor(p => p.Description).MaximumLength(255);
            RuleFor(p => p.TemplateType).NotEmpty();
            RuleFor(p => p.TemplateType).MaximumLength(100);
            #endregion
        }

    }
}
