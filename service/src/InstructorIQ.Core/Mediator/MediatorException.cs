using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator
{
    public class MediatorException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Exception"></see> class with a specified error message.</summary>
        /// <param name="statusCode"></param>
        /// <param name="message">The message that describes the error.</param>
        public MediatorException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Exception"></see> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="statusCode"></param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public MediatorException(int statusCode, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}
