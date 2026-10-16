using System;
using System.Collections.Generic;
using System.Security.Claims;

using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record TopicHistoryQuery : EntityIdentifierQuery<Guid, IReadOnlyCollection<AuditRecord<Guid>>>
{
    public TopicHistoryQuery(ClaimsPrincipal principal, Guid id) : base(principal, id)
    {

    }
}
