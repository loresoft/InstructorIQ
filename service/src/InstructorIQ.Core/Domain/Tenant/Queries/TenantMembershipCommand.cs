using System.Security.Principal;
using MediatR.CommandQuery.Commands;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class TenantMembershipCommand : PrincipalCommandBase<TenantMembershipModel>
    {

        public TenantMembershipCommand(IPrincipal principal, TenantMembershipModel membership) : base(principal)
        {
            Membership = membership;
        }

        public TenantMembershipModel Membership { get; set; }
    }
}

