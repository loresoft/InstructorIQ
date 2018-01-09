using System;
using System.Security.Principal;
using InstructorIQ.Core.Mediator.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace InstructorIQ.Core.Mediator.Commands
{
    public class EntityPatchCommand<TEntity, TReadModel> : EntityIdentifierCommand<TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        public EntityPatchCommand(Guid id, JsonPatchDocument<TEntity> patch, IPrincipal principal) : base(id, principal)
        {
            Patch = patch ?? throw new ArgumentNullException(nameof(patch));
        }

        public JsonPatchDocument<TEntity> Patch { get; set; }

        public TReadModel Original { get; set; }
    }
}