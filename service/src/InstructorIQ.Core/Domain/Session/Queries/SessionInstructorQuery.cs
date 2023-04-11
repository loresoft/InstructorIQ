using System;
using System.Collections.Generic;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class SessionInstructorQuery : PrincipalQueryBase<IReadOnlyCollection<SessionInstructorModel>>
{
    public SessionInstructorQuery(IPrincipal principal, Guid sessionId) : base(principal)
    {
        SessionId = sessionId;
    }

    public Guid SessionId { get; }
}
