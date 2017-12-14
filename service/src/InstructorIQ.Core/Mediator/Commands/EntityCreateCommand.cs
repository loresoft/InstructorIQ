using System;
using System.Security.Principal;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Commands
{
    public class EntityCreateCommand<TEntity, TCreateModel, TReadModel> : EntityModelCommand<TCreateModel, TReadModel>
        where TEntity : class, new()
        where TCreateModel : EntityCreateModel
        where TReadModel : EntityReadModel
    {
        public EntityCreateCommand(TCreateModel model, IPrincipal principal) : base(model, principal)
        {
            Model.Created = DateTimeOffset.UtcNow;
            Model.Updated = DateTimeOffset.UtcNow;

            if (principal?.Identity?.IsAuthenticated != true)
                return;

            var identityName = principal.Identity.Name;

            Model.CreatedBy = identityName;
            Model.UpdatedBy = identityName;
        }
    }
}
