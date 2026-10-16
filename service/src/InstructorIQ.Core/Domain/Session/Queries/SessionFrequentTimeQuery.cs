using System;
using System.Collections.Generic;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

namespace InstructorIQ.Core.Domain.Queries;

public record SessionFrequentTimeQuery : PrincipalQueryBase<IReadOnlyCollection<SessionFrequentTimeModel>>
{
    public SessionFrequentTimeQuery(ClaimsPrincipal principal, Guid tenantId) : base(principal)
    {
        TenantId = tenantId;
    }

    public Guid TenantId { get; }
}
