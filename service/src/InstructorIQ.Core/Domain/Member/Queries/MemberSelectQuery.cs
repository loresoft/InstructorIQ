using System;
using System.Collections.Generic;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class MemberSelectQuery : EntitySelectQuery<MemberReadModel>
    {
        public MemberSelectQuery(IPrincipal principal, Guid tenantId) : base(principal)
        {
            TenantId = tenantId;
        }

        public MemberSelectQuery(IPrincipal principal, EntityFilter filter, IEnumerable<EntitySort> sort, Guid tenantId) : base(principal, filter, sort)
        {
            TenantId = tenantId;
        }

        public Guid TenantId { get; }

        public string RoleName { get; set; }
    }
}