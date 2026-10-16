using System;
using System.Collections.Generic;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record GroupSequenceQuery : PrincipalQueryBase<IReadOnlyCollection<GroupSequenceModel>>
{
    public GroupSequenceQuery(ClaimsPrincipal principal) : base(principal)
    {
    }
}
