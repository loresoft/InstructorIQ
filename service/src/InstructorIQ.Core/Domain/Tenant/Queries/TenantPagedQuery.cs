using System.Security.Principal;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using MediatR;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class TenantPagedQuery : EntityPagedQuery<TemplateReadModel>, IRequest<TenantPagedResult>
    {
        public TenantPagedQuery(IPrincipal principal, EntityQuery query) : base(principal, query)
        {
        }
    }
}
