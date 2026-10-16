using System;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record MemberSelectQuery : EntitySelectQuery<MemberReadModel>
{
    public MemberSelectQuery(ClaimsPrincipal principal, Guid tenantId)
        : this(principal, new EntitySelect(), tenantId)
    {
    }

    public MemberSelectQuery(ClaimsPrincipal principal, EntitySelect select, Guid tenantId)
        : base(principal, select)
    {
        TenantId = tenantId;
    }

    public Guid TenantId { get; }

    public Guid? RoleId { get; set; }
}
