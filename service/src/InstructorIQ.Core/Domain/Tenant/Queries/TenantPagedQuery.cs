using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record TenantPagedQuery : EntityPagedQuery<TenantReadModel>
{
    public TenantPagedQuery(ClaimsPrincipal principal, EntityQuery query) : base(principal, query)
    {
    }
}
