using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="TopicInstructorUpdateModel"/> .
    /// </summary>
    public partial class TopicInstructorUpdateModelValidator
        : AbstractValidator<TopicInstructorUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopicInstructorUpdateModelValidator"/> class.
        /// </summary>
        public TopicInstructorUpdateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
