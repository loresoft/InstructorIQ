using System;
using System.Collections.Generic;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class GroupSequenceQuery : PrincipalQueryBase<IReadOnlyCollection<GroupSequenceModel>>
{
    public GroupSequenceQuery(IPrincipal principal) : base(principal)
    {
    }
}
