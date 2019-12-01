using System;
using MediatR.CommandQuery.Definitions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class MemberReadModel : IHaveIdentifier<Guid>
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string GivenName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }

        public string DisplayName { get; set; }

        public string SortName { get; set; }

        public string JobTitle { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public int AccessFailedCount { get; set; }

        public Guid? LastTenantId { get; set; }

        public bool IsGlobalAdministrator { get; set; }
    }
}
