using System.Collections.Generic;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record GroupDropdownQuery : PrincipalQueryBase<IReadOnlyCollection<GroupDropdownModel>>
{
    public GroupDropdownQuery(ClaimsPrincipal principal) : base(principal)
    {
    }
}
