using System;
using System.Collections.Generic;
using System.Security.Principal;

using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class SessionHistoryQuery : CacheableQueryBase<IReadOnlyCollection<AuditRecord<Guid>>>
{
    public SessionHistoryQuery(IPrincipal principal) : base(principal)
    {
    }

    public Guid? Id { get; set; }

    public Guid? TopicId { get; set; }

    public override string GetCacheKey()
    {
        var hash = HashCode.Combine(Id, TopicId);
        return $"{nameof(SessionHistoryQuery)}-{hash}";
    }
}
