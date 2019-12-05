using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands
{
    public class TopicCreateMultipleCommand : PrincipalCommandBase<CommandCompleteModel>
    {
        public TopicCreateMultipleCommand(IPrincipal principal, IEnumerable<TopicCreateModel> topics) : base(principal)
        {
            if (topics == null)
                throw new ArgumentNullException(nameof(topics));

            Topics = topics.ToList();
        }

        public List<TopicCreateModel> Topics { get; }
    }
}
