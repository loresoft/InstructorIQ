using System;
using System.Security.Principal;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Commands
{
    public class EntityDeleteCommand<TEntity, TReadModel> : EntityIdentifierCommand<TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        public EntityDeleteCommand(Guid id, IPrincipal principal) : base(id, principal)
        {
        }
    }
}