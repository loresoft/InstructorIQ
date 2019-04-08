using System.Collections.Generic;
using System.Security.Principal;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class InstructorDropdownQuery : PrincipalQueryBase<IReadOnlyCollection<InstructorDropdownModel>>
    {
        public InstructorDropdownQuery(IPrincipal principal) : base(principal)
        {
        }
    }
}
