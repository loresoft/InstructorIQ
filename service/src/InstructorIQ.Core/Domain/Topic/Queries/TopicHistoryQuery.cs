using System;
using System.Collections.Generic;
using System.Security.Principal;
using InstructorIQ.Core.Models;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class TopicHistoryQuery : EntityIdentifierQuery<Guid, IReadOnlyCollection<HistoryRecord>>
    {
        public TopicHistoryQuery(IPrincipal principal, Guid id) : base(principal, id)
        {

        }
    }
}
