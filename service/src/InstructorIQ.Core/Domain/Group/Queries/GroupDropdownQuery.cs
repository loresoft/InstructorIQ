using System.Collections.Generic;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class GroupDropdownQuery : PrincipalQueryBase<IReadOnlyCollection<GroupDropdownModel>>
{
    public GroupDropdownQuery(IPrincipal principal) : base(principal)
    {
    }
}
