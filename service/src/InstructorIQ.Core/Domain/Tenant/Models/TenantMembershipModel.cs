using System;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class TenantMembershipModel
    {
        public Guid TenantId { get; set; }

        public Guid UserId { get; set; }

        public bool IsMember { get; set; }

        public bool IsAttendee { get; set; }

        public bool IsInstructor { get; set; }

        public bool IsAdministrator { get; set; }

    }
}
