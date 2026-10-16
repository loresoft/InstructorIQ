using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public record MemberAssignRoleCommand : PrincipalCommandBase<CompleteModel>
{
    public MemberAssignRoleCommand(ClaimsPrincipal principal, Guid tenantId, IEnumerable<string> users, IEnumerable<string> roles)
        : base(principal)
    {
        TenantId = tenantId;
        Users = users.ToList();
        Roles = roles.ToList();
    }

    public Guid TenantId { get; }

    public List<string> Users { get; }

    public List<string> Roles { get; }
}
