using System;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class MemberSelectQuery : EntitySelectQuery<MemberReadModel>
    {
        public MemberSelectQuery(IPrincipal principal, Guid tenantId)
            : this(principal, new EntitySelect(), tenantId)
        {
        }

        public MemberSelectQuery(IPrincipal principal, EntitySelect select, Guid tenantId)
            : base(principal, select)
        {
            TenantId = tenantId;
        }

        public Guid TenantId { get; }

        public Guid? RoleId { get; set; }
    }
}