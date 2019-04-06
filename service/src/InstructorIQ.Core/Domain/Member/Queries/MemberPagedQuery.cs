using System;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Queries
{
    public class MemberPagedQuery : EntityPagedQuery<MemberReadModel>
    {
        public MemberPagedQuery(EntityQuery query, Guid tenantId, IPrincipal principal) : base(query, principal)
        {
            TenantId = tenantId;
        }

        public Guid TenantId { get; set; }
    }
}
