using System;
using System.Collections.Generic;
using System.Linq;
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
            TopicIds = new List<Guid> { topicId };
        }

        public SessionTopicQuery(IPrincipal principal, IEnumerable<Guid> topicIds) : base(principal)
        {
            TopicIds = topicIds.ToList();
        }

        public IReadOnlyCollection<Guid> TopicIds { get; set; }
    }
}
