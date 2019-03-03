using System.Collections.Generic;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class InstructorDropdownQuery : IRequest<IReadOnlyCollection<InstructorDropdownModel>>
    {
        public InstructorDropdownQuery()
        {
        }

        public InstructorDropdownQuery(IPrincipal principal)
        {
            Principal = principal;
        }

        public IPrincipal Principal { get; set; }
    }
}
