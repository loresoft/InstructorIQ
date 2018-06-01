using System;

namespace InstructorIQ.Core.Domain.User.Models
{
    public class UserRegisterModel
    {
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}