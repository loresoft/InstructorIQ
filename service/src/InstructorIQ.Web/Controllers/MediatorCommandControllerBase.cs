using System;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace InstructorIQ.Web.Controllers
{
    public abstract class MediatorCommandControllerBase<TEntity, TReadModel, TCreateModel, TUpdateModel> : MediatorQueryControllerBase<TEntity, TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
        where TCreateModel : EntityCreateModel
        where TUpdateModel : EntityUpdateModel
    {
        protected MediatorCommandControllerBase(IMediator mediator) : base(mediator)
        {
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