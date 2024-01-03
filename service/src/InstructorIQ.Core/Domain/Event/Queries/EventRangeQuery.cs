using System;
using System.Collections.Generic;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

namespace InstructorIQ.Core.Domain.Queries;

public class EventRangeQuery : PrincipalQueryBase<IReadOnlyCollection<EventReadModel>>
{
    public EventRangeQuery(IPrincipal principal, Guid tenantId, DateOnly start, DateOnly end) : base(principal)
    {
        TenantId = tenantId;
        Start = start;
        End = end;
    }

    public Guid TenantId { get; set; }

    public DateOnly Start { get; set; }

    public DateOnly End { get; set; }
}
