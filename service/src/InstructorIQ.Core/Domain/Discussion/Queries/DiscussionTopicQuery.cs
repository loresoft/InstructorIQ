using System;
using System.Collections.Generic;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record DiscussionTopicQuery : PrincipalQueryBase<IReadOnlyCollection<DiscussionReadModel>>
{
    public DiscussionTopicQuery(ClaimsPrincipal principal, Guid topicId) : base(principal)
    {
        TopicId = topicId;
    }

    public Guid TopicId { get; }
}
