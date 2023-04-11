using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class TenantMembershipCommand : PrincipalCommandBase<TenantMembershipModel>
{

    public TenantMembershipCommand(IPrincipal principal, TenantMembershipModel membership) : base(principal)
    {
        Membership = membership;
    }

    public TenantMembershipModel Membership { get; set; }
}

