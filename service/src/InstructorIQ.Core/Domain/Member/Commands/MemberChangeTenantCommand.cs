using System;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;

namespace InstructorIQ.Core.Domain.Commands;

public record MemberChangeTenantCommand : PrincipalCommandBase<MemberReadModel>
{
    public MemberChangeTenantCommand(ClaimsPrincipal principal, Guid tenantId) : base(principal)
    {
        TenantId = tenantId;
    }

    public Guid TenantId { get; set; }
}
