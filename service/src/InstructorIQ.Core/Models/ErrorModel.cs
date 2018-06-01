using System;
using System.Collections.Generic;

namespace InstructorIQ.Core.Infrastructure.Models
{
    public class ErrorModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }

        public IList<ValidationErrorModel> Errors { get; set; }

    }
}
