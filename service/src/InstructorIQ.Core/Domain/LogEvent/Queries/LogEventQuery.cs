using System;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

namespace InstructorIQ.Core.Domain.Queries;

public record LogEventQuery : PrincipalQueryBase<LogPagedResult>
{
    public LogEventQuery(ClaimsPrincipal principal) : base(principal)
    {

    }

    public string ContinuationToken { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;

    public string Level { get; set; }

    public int PageSize { get; set; } = 100;
}
