using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class TenantPagedQuery : EntityPagedQuery<TenantReadModel>
{
    public TenantPagedQuery(IPrincipal principal, EntityQuery query) : base(principal, query)
    {
    }
}
