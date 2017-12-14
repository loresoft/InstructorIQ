using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace InstructorIQ.Core.Mediator.Models
{
    public class ErrorModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }

        public IList<ValidationErrorModel> Errors { get; set; }

    }
}
