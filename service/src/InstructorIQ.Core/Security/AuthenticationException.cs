using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Security
{
    public class AuthenticationException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Exception"></see> class with a specified error message.</summary>
        /// <param name="errorType">The error type</param>
        /// <param name="message">The message that describes the error.</param>
        public AuthenticationException(string errorType, string message) : base(message)
        {
            ErrorType = errorType;
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Exception"></see> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="errorType">The error type</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public AuthenticationException(string errorType, string message, Exception innerException) : base(message, innerException)
        {
            ErrorType = errorType;
        }

        public string ErrorType { get; }
    }
}
