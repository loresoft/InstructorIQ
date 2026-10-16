using System;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record TenantMembershipQuery : PrincipalQueryBase<TenantMembershipModel>
{
    public TenantMembershipQuery(ClaimsPrincipal principal, Guid tenantId, Guid userId) : base(principal)
    {
        TenantId = tenantId;
        UserId = userId;
    }

    public Guid TenantId { get; set; }

    public Guid UserId { get; set; }

}

