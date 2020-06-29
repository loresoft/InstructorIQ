using System;
using System.Security.Principal;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class MemberPagedQuery : EntityPagedQuery<MemberReadModel>
    {
        public MemberPagedQuery(IPrincipal principal, EntityQuery query, Guid tenantId) : base(principal, query)
        {
            TenantId = tenantId;
        }

        public Guid TenantId { get; }

        public Guid? RoleId { get; set; }
    }
}
