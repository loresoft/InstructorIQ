using System;
using System.Collections.Generic;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Queries;

namespace InstructorIQ.Core.Domain.Queries
{
    public class SessionFrequentTimeQuery : PrincipalQueryBase<IReadOnlyCollection<SessionFrequentTimeModel>>
    {
        public SessionFrequentTimeQuery(IPrincipal principal, Guid tenantId) : base(principal)
        {
            TenantId = tenantId;
        }

        public Guid TenantId { get; }
    }
}
