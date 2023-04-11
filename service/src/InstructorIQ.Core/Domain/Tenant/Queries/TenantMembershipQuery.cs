using System;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

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

