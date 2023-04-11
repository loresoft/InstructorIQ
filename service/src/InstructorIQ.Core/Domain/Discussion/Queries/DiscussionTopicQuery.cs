using System;
using System.Collections.Generic;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class DiscussionTopicQuery : PrincipalQueryBase<IReadOnlyCollection<DiscussionReadModel>>
{
    public DiscussionTopicQuery(IPrincipal principal, Guid topicId) : base(principal)
    {
        TopicId = topicId;
    }

    public Guid TopicId { get; }
}
