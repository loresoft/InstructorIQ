using System;
using InstructorIQ.Core.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class UserResetPasswordEmail
    {
        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public string ResetLink { get; set; }

        public UserAgentModel UserAgent { get; set; }
    }
}