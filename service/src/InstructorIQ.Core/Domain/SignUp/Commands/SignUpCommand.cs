using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

namespace InstructorIQ.Core.Domain.Commands;

public record SignUpCommand : PrincipalCommandBase<CompleteModel>
{
    public SignUpCommand(ClaimsPrincipal principal, Guid id, SignUpUpdateModel instructorSignUp, IEnumerable<SignUpTopicUpdateModel> instructorSignUpTopics)
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
