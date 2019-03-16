using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Commands;
using InstructorIQ.Core.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands
{
    public class SessionSequenceCreateCommand : PrincipalCommandBase<CommandCompleteModel>
    {
        public SessionSequenceCreateCommand(IPrincipal principal, Guid topicId, IEnumerable<int> sequences) : base(principal)
        {
            TopicIds = new List<Guid> { topicId };
            Sequences = sequences.ToList();
        }

        public SessionSequenceCreateCommand(IPrincipal principal, IEnumerable<Guid> topicIds, IEnumerable<int> sequences) : base(principal)
        {
            TopicIds = topicIds.ToList();
            Sequences = sequences.ToList();
        }

        public IReadOnlyCollection<Guid> TopicIds { get; set; }

        public IReadOnlyCollection<int> Sequences { get; set; }

    }
}