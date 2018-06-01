using System;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class UserChangePasswordModel
    {
        public string CurrentPassword { get; set; }

        public string UpdatedPassword { get; set; }
    }
}