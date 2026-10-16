using System;
using System.Collections.Generic;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record SessionCalendarQuery : PrincipalQueryBase<IReadOnlyCollection<SessionCalendarModel>>
{
    public SessionCalendarQuery(ClaimsPrincipal principal, Guid tenantId, int year)
        : base(principal)
    {
        TenantId = tenantId;

        StartDate = new DateOnly(year, 1, 1);
        EndDate = StartDate.AddYears(1);
    }

    public SessionCalendarQuery(ClaimsPrincipal principal, Guid tenantId, int year, int month)
        : base(principal)
    {
        TenantId = tenantId;

        StartDate = new DateOnly(year, month, 1);
        EndDate = StartDate.AddMonths(1);
    }

    public SessionCalendarQuery(ClaimsPrincipal principal, Guid tenantId, DateOnly startDate, DateOnly endDate)
        : base(principal)
    {
        TenantId = tenantId;

        StartDate = startDate;
        EndDate = endDate;
    }


    public Guid TenantId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}
