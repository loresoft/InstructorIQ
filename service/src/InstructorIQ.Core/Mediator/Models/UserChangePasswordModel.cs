using System;

namespace InstructorIQ.Core.Mediator.Models
{
    public class UserChangePasswordModel
    {
        public string CurrentPassword { get; set; }

        public string UpdatedPassword { get; set; }
    }
}