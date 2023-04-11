using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

namespace InstructorIQ.Core.Domain.Commands;

public class SignUpCommand : PrincipalCommandBase<CompleteModel>
{
    public SignUpCommand(IPrincipal principal, Guid id, SignUpUpdateModel instructorSignUp, IEnumerable<SignUpTopicUpdateModel> instructorSignUpTopics)
        : base(principal)
    {
        InstructorSignUp = instructorSignUp;
        InstructorSignUpTopics = instructorSignUpTopics.ToList();
        Id = id;
    }

    public Guid Id { get; }

    public SignUpUpdateModel InstructorSignUp { get; }

    public List<SignUpTopicUpdateModel> InstructorSignUpTopics { get; }
}
