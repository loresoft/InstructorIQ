using System;
using System.Security.Principal;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class TenantMembershipQuery : PrincipalQueryBase<TenantMembershipModel>
    {
        public TenantMembershipQuery(IPrincipal principal, Guid tenantId, Guid userId) : base(principal)
        {
            TenantId = tenantId;
            UserId = userId;
        }

        public Guid TenantId { get; set; }

        public Guid UserId { get; set; }

    }
}

