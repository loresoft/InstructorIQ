using System;
using System.Security.Principal;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Commands
{
    public class EntityUpdateCommand<TEntity, TUpdateModel, TReadModel> : IRequest<TReadModel>
        where TEntity : class, new()
        where TUpdateModel : EntityUpdateModel
        where TReadModel : EntityReadModel
    {
        public EntityUpdateCommand(Guid id, TUpdateModel model, IPrincipal principal)
        {
            Id = id;
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Principal = principal;

            if (principal?.Identity?.IsAuthenticated != true)
                return;

            var identityName = principal.Identity.Name;

            Model.UpdatedBy = identityName;
        }

        public IPrincipal Principal { get; set; }

        public Guid Id { get; set; }

        public TUpdateModel Model { get; set; }

        public bool Upsert { get; set; } = true;

        public TReadModel Original { get; set; }
    }
}