using System;
using System.Security.Principal;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Commands
{
    public class EntityDeleteCommand<TEntity, TReadModel> : IRequest<TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        public EntityDeleteCommand(Guid id, IPrincipal principal)
        {
            Id = id;
            Principal = principal;
        }

        public IPrincipal Principal { get; set; }

        public Guid Id { get; set; }
    }
}