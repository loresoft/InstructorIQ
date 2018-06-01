using System;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class UserResetPasswordModel
    {
        public string EmailAddress { get; set; }
        public string ResetToken { get; set; }
        public string UpdatedPassword { get; set; }
    }
}