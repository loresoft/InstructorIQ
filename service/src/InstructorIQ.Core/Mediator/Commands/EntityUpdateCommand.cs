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
            if (id == default(Guid))
                throw new ArgumentException($"Invalid value for entity Id: {id}", nameof(id));

            Id = id;
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Principal = principal;

            Model.Updated = DateTimeOffset.UtcNow;

            if (principal?.Identity?.IsAuthenticated != true)
                return;

            var identityName = principal.Identity.Name;

            Model.UpdatedBy = identityName;
        }

        public IPrincipal Principal { get; set; }

        public Guid Id { get; set; }

        public TUpdateModel Model { get; set; }

        public TReadModel Original { get; set; }
    }
}