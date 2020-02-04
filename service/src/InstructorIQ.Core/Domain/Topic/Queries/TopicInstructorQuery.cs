using System;
using System.Collections.Generic;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class TopicInstructorQuery : EntityIdentifierQuery<Guid, IReadOnlyCollection<InstructorReadModel>>
    {
        public TopicInstructorQuery(IPrincipal principal, Guid id) : base(principal, id)
        {

        }
    }
}
