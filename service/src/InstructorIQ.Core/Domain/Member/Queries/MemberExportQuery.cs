using System;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Queries;

namespace InstructorIQ.Core.Domain.Queries
{
    public class MemberExportQuery : EntitySelectQuery<MemberImportModel>
    {
        public MemberExportQuery(IPrincipal principal, Guid tenantId) : base(principal)
        {
            TenantId = tenantId;
        }

        public Guid TenantId { get; }
    }
}