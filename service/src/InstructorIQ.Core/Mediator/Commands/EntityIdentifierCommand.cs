using System;
using System.Security.Principal;
using MediatR;

namespace InstructorIQ.Core.Mediator.Commands
{
    public abstract class EntityIdentifierCommand<TReadModel> : IRequest<TReadModel>
    {
        protected EntityIdentifierCommand(Guid id, IPrincipal principal)
        {
            Id = id;
            Principal = principal;
        }

        public IPrincipal Principal { get; set; }

        public Guid Id { get; set; }
    }
}