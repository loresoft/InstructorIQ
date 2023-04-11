using System;
using System.Collections.Generic;
using System.Security.Principal;

using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class SessionInstructorHistoryQuery : CacheableQueryBase<IReadOnlyCollection<AuditRecord<Guid>>>
{
    public SessionInstructorHistoryQuery(IPrincipal principal) : base(principal)
    {
    }

    public Guid? SessionId { get; set; }

    public Guid? TopicId { get; set; }

    public override string GetCacheKey()
    {
        var hash = HashCode.Combine(SessionId, TopicId);
        return $"{nameof(SessionHistoryQuery)}-{hash}";
    }
}
