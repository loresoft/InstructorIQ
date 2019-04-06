using System;

namespace InstructorIQ.Core.Domain.Models
{
    public class TenantMembershipModel
    {
        public Guid TenantId { get; set; }

        public string UserName { get; set; }

        public bool IsMember { get; set; }

        public bool IsInstructor { get; set; }

        public bool IsAdministrator { get; set; }

    }
}
