using System.Collections.Generic;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class GroupDropdownQuery : IRequest<IReadOnlyCollection<GroupDropdownModel>>
    {
        public GroupDropdownQuery()
        {
        }

        public GroupDropdownQuery(IPrincipal principal)
        {
            Principal = principal;
        }

        public IPrincipal Principal { get; set; }
    }
}
