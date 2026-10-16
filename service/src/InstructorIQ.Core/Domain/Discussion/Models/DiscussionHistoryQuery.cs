using System;
using System.Collections.Generic;
using System.Security.Claims;

using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.Queries;

namespace InstructorIQ.Core.Domain.Models;

public record DiscussionHistoryQuery : CacheableQueryBase<IReadOnlyCollection<AuditRecord<Guid>>>
{
    public DiscussionHistoryQuery(ClaimsPrincipal principal) : base(principal)
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
