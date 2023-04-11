using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

namespace InstructorIQ.Core.Domain.Commands;

public class SessionInstructorUpdateCommand : PrincipalCommandBase<CompleteModel>
{
    public SessionInstructorUpdateCommand(IPrincipal principal, Guid sessionId, IEnumerable<Guid> instructors) :
        base(principal)
    {
        SessionId = sessionId;
        Instructors = instructors.ToList();
    }

    public Guid SessionId { get; set; }

    public List<Guid> Instructors { get; set; }
}
