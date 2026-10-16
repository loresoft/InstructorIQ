using System.Collections.Generic;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record LocationDropdownQuery : PrincipalQueryBase<IReadOnlyCollection<LocationDropdownModel>>
{
    public LocationDropdownQuery(ClaimsPrincipal principal) : base(principal)
    {
    }
}
