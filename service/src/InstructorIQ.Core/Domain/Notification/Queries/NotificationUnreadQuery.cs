using System;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record NotificationUnreadQuery : PrincipalQueryBase<NotificationUnreadModel>
{
    public NotificationUnreadQuery(ClaimsPrincipal principal, string userName, Guid tenantId) : base(principal)
    {
        UserName = userName;
        TenantId = tenantId;
    }

    public string UserName { get; }

    public Guid TenantId { get; }
}
