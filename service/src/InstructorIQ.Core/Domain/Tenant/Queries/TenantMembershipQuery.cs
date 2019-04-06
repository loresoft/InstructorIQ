using System;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class TenantMembershipQuery : PrincipalQueryBase<TenantMembershipModel>
    {
        public TenantMembershipQuery(IPrincipal principal, Guid tenantId, string userName) : base(principal)
        {
            TenantId = tenantId;
            UserName = userName;
        }

        public Guid TenantId { get; set; }

        public string UserName { get; set; }

    }
}

