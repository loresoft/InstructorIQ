using System;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Models;

namespace EntityFrameworkCore.CommandQuery.Commands
{
    public class EntityDeleteCommand<TKey, TEntity, TReadModel> : EntityIdentifierCommand<TKey, TReadModel>
        where TEntity : class, new()
    {
        public EntityDeleteCommand(TKey id, IPrincipal principal) : base(id, principal)
        {
        }
    }
}