using System;
using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Domain.Models
{
    public class MemberReadModel : IHaveIdentifier<Guid>
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string DisplayName { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public int AccessFailedCount { get; set; }

        public Guid? LastTenantId { get; set; }

        public bool IsGlobalAdministrator { get; set; }
    }
}
