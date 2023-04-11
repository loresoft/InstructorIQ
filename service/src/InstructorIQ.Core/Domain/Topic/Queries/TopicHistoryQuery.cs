using System;
using System.Collections.Generic;
using System.Security.Principal;

using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class TopicHistoryQuery : EntityIdentifierQuery<Guid, IReadOnlyCollection<AuditRecord<Guid>>>
{
    public TopicHistoryQuery(IPrincipal principal, Guid id) : base(principal, id)
    {

    }
}
