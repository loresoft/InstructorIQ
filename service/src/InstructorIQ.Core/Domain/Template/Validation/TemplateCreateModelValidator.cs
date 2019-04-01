using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="TemplateCreateModel"/> .
    /// </summary>
    public partial class TemplateCreateModelValidator
        : AbstractValidator<TemplateCreateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateCreateModelValidator"/> class.
        /// </summary>
        public TemplateCreateModelValidator()
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
