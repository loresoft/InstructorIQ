using System;
using System.Collections.Generic;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class SessionTopicQuery : PrincipalQueryBase<IReadOnlyCollection<SessionReadModel>>
    {

        public SessionTopicQuery(IPrincipal principal, Guid topicId) : base(principal)
        {
            TopicId = topicId;
        }

        public SessionTopicQuery(IPrincipal principal, Guid topicId, string sort)
            : this(principal, topicId)
        {
            Sort = EntitySort.Parse(sort);
        }

        public Guid TopicId { get; set; }

        public EntitySort Sort { get; set; }
    }
}
