using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

namespace InstructorIQ.Core.Domain.Commands;

public class TopicInstructorSignUpCommand : PrincipalCommandBase<CompleteModel>
{
    public TopicInstructorSignUpCommand(IPrincipal principal, Guid instructorId, IEnumerable<Guid> topics) : base(principal)
    {
        InstructorId = instructorId;
        Topics = topics.ToList();
    }

    public Guid InstructorId { get; }

    public List<Guid> Topics { get; }
}
