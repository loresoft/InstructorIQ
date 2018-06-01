using System;

namespace InstructorIQ.Core.Infrastructure.Models
{
    public class ValidationErrorModel
    {
        public string Field { get; }

        public string Message { get; }

        public object Value { get; set; }

        public ValidationErrorModel(string field, string message, object value = null)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
            Value = value;
        }
    }
}