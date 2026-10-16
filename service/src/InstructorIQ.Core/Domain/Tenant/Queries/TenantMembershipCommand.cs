using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record TenantMembershipCommand : PrincipalCommandBase<TenantMembershipModel>
{

    public TenantMembershipCommand(ClaimsPrincipal principal, TenantMembershipModel membership) : base(principal)
    {
        Membership = membership;
    }

    public TenantMembershipModel Membership { get; set; }
}

