using System;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Commands;

namespace InstructorIQ.Core.Domain.Commands
{
    public class MemberChangeTenantCommand : PrincipalCommandBase<MemberReadModel>
    {
        public MemberChangeTenantCommand(IPrincipal principal, Guid tenantId) : base(principal)
        {
            TenantId = tenantId;
        }

        public Guid TenantId { get; set; }
    }
}
