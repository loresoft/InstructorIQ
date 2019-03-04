using System.Collections.Generic;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class LocationDropdownQuery : PrincipalQueryBase<IReadOnlyCollection<LocationDropdownModel>>
    {
        public LocationDropdownQuery(IPrincipal principal) : base(principal)
        {
        }
    }
}
