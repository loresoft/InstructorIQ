using System;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.Web.Controllers
{
    public abstract class MediatorController<TEntity, TReadModel, TCreateModel, TUpdateModel> : Controller
        where TEntity : class, new()
        where TReadModel : EntityReadModel
        where TCreateModel : EntityCreateModel
        where TUpdateModel : EntityUpdateModel
    {
        protected MediatorController(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }


        protected virtual async Task<TReadModel> GetQuery(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityIdentifierQuery<TEntity, TReadModel>(id, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }

        protected virtual async Task<EntityListResult<TReadModel>> ListQuery(EntityQuery entityQuery, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityListQuery<TEntity, TReadModel>(entityQuery, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }


        protected virtual async Task<TReadModel> CreateCommand(TCreateModel createModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityCreateCommand<TEntity, TCreateModel, TReadModel>(createModel, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }

        protected virtual async Task<TReadModel> UpdateCommand(Guid id, TUpdateModel updateModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityUpdateCommand<TEntity, TUpdateModel, TReadModel>(id, updateModel, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }

        protected virtual async Task<TReadModel> PatchCommand(Guid id, JsonPatchDocument<TEntity> jsonPatch, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityPatchCommand<TEntity, TReadModel>(id, jsonPatch, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }

        protected virtual async Task<TReadModel> DeleteCommand(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityDeleteCommand<TEntity, TReadModel>(id, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }
    }
}