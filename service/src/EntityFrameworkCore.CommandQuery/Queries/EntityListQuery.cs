using System;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Models;
using MediatR;

namespace EntityFrameworkCore.CommandQuery.Queries
{
    public class EntityListQuery<TEntity, TReadModel> : IRequest<EntityListResult<TReadModel>>
        where TEntity : class
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