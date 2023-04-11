using System.Collections.Generic;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class TenantDropdownQuery : PrincipalQueryBase<IReadOnlyCollection<TenantDropdownModel>>
{
    public TenantDropdownQuery(IPrincipal principal) : base(principal)
    {
    }
}
