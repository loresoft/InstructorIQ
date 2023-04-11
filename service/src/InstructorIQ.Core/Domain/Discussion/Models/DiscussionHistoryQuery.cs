using System;
using System.Collections.Generic;
using System.Security.Principal;

using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.Queries;

namespace InstructorIQ.Core.Domain.Models;

public class DiscussionHistoryQuery : CacheableQueryBase<IReadOnlyCollection<AuditRecord<Guid>>>
{
    public DiscussionHistoryQuery(IPrincipal principal) : base(principal)
    {
    }

    public Guid? Id { get; set; }

    public Guid? TopicId { get; set; }

    public override string GetCacheKey()
    {
        var hash = HashCode.Combine(Id, TopicId);
        return $"{nameof(DiscussionHistoryQuery)}-{hash}";
    }
}
