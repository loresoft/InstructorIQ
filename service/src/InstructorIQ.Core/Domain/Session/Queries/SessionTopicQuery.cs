using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record SessionTopicQuery : PrincipalQueryBase<IReadOnlyCollection<SessionCalendarModel>>
{

    public SessionTopicQuery(ClaimsPrincipal principal, Guid topicId) : base(principal)
    {
        TopicIds = new List<Guid> { topicId };
    }

    public SessionTopicQuery(ClaimsPrincipal principal, IEnumerable<Guid> topicIds) : base(principal)
    {
        TopicIds = topicIds.ToList();
    }

    public IReadOnlyCollection<Guid> TopicIds { get; set; }
}
