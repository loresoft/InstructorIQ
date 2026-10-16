using System;
using System.Collections.Generic;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

namespace InstructorIQ.Core.Domain.Queries;

public record EventRangeQuery : PrincipalQueryBase<IReadOnlyCollection<EventReadModel>>
{
    public EventRangeQuery(ClaimsPrincipal principal, Guid tenantId, DateOnly start, DateOnly end) : base(principal)
    {
        TenantId = tenantId;
        Start = start;
        End = end;
    }

    public Guid TenantId { get; set; }

    public DateOnly Start { get; set; }

    public DateOnly End { get; set; }
}
