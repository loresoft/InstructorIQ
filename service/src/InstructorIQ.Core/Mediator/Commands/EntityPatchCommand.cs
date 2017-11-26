using System;
using System.Security.Principal;
using InstructorIQ.Core.Mediator.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace InstructorIQ.Core.Mediator.Commands
{
    public class EntityPatchCommand<TEntity, TReadModel> : IRequest<TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        public EntityPatchCommand(Guid id, JsonPatchDocument<TEntity> patch, IPrincipal principal)
        {
            Principal = principal;
            Id = id;
            Patch = patch;
        }

        public IPrincipal Principal { get; set; }

        public Guid Id { get; set; }

        public JsonPatchDocument<TEntity> Patch { get; set; }

        public TReadModel Original { get; set; }
    }
}