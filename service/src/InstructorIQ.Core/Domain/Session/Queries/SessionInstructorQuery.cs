using System;
using System.Collections.Generic;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record SessionInstructorQuery : PrincipalQueryBase<IReadOnlyCollection<SessionInstructorModel>>
{
    public SessionInstructorQuery(ClaimsPrincipal principal, Guid sessionId) : base(principal)
    {
        SessionId = sessionId;
    }

    public Guid SessionId { get; }
}
