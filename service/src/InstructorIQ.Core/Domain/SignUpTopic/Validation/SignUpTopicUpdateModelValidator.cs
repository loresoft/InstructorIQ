using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Validation
{
    /// <summary>
    /// Validator class for <see cref="SignUpTopicUpdateModel"/> .
    /// </summary>
    public partial class SignUpTopicUpdateModelValidator
        : AbstractValidator<SignUpTopicUpdateModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpTopicUpdateModelValidator"/> class.
        /// </summary>
        public SignUpTopicUpdateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
