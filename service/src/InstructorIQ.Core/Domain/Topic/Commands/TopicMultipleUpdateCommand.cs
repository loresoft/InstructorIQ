using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public class TopicMultipleUpdateCommand : PrincipalCommandBase<CompleteModel>
{
    public TopicMultipleUpdateCommand(IPrincipal principal, IEnumerable<TopicMultipleUpdateModel> topics) : base(principal)
    {
        if (topics == null)
            throw new ArgumentNullException(nameof(topics));

        Topics = topics.ToList();
    }

    public List<TopicMultipleUpdateModel> Topics { get; }
}
