using System;
using System.Security.Principal;
using MediatR;

namespace InstructorIQ.Core.Mediator.Commands
{
    public abstract class EntityModelCommand<TEntityModel, TReadModel> : IRequest<TReadModel>
    {
        protected EntityModelCommand(TEntityModel model, IPrincipal principal)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Model = model;
            Principal = principal;
        }

        public IPrincipal Principal { get; set; }

        public TEntityModel Model { get; set; }

    }
}