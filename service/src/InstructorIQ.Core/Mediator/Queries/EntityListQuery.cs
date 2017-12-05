using System;
using System.Security.Principal;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Queries
{
    public class EntityListQuery<TEntity, TReadModel> : IRequest<EntityListResult<TReadModel>>
        where TEntity : class
        where TReadModel : EntityReadModel
    {
        public EntityListQuery(EntityQuery query, IPrincipal principal)
        {
            Query = query;
            Principal = principal;
        }

        public IPrincipal Principal { get; set; }

        public EntityQuery Query { get; set; }
    }
}