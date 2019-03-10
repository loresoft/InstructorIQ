using System;

namespace InstructorIQ.Core.Domain.Models
{
    public class SessionInstructorModel
    {
        public Guid SessionId { get; set; }

        public Guid InstructorId { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string DisplayName { get; set; }
    }
}