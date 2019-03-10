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
            TopicId = topicId;
            Sequences = sequences.ToList();
        }

        public Guid TopicId { get; set; }

        public List<int> Sequences { get; set; }

    }
}