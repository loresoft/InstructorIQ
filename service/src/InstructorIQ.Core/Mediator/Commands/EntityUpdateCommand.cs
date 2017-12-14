using System;
using System.Security.Principal;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Commands
{
    public class EntityUpdateCommand<TEntity, TUpdateModel, TReadModel> : EntityModelCommand<TUpdateModel, TReadModel>
        where TEntity : class, new()
        where TUpdateModel : EntityUpdateModel
        where TReadModel : EntityReadModel
    {
        public EntityUpdateCommand(Guid id, TUpdateModel model, IPrincipal principal) : base(model, principal)
        {
            if (id == default(Guid))
                throw new ArgumentException($"Invalid value for entity Id: {id}", nameof(id));

            Id = id;

            Model.Updated = DateTimeOffset.UtcNow;

            if (principal?.Identity?.IsAuthenticated != true)
                return;

            var identityName = principal.Identity.Name;

            Model.UpdatedBy = identityName;
        }

        public Guid Id { get; set; }

        public TReadModel Original { get; set; }
    }
}