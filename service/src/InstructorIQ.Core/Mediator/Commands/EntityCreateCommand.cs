using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Commands
{
    public class EntityCreateCommand<TEntity, TCreateModel, TReadModel> : IRequest<TReadModel>
        where TEntity : class, new()
        where TCreateModel : EntityCreateModel
        where TReadModel : EntityReadModel
    {
        public EntityCreateCommand(TCreateModel model, IPrincipal principal)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Principal = principal;

            if (principal?.Identity?.IsAuthenticated != true)
                return;

            var identityName = principal.Identity.Name;

            Model.CreatedBy = identityName;
            Model.UpdatedBy = identityName;
        }

        public IPrincipal Principal { get; set; }
        public TCreateModel Model { get; set; }
    }
}
