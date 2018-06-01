using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace InstructorIQ.Web.Controllers
{
    public abstract class MediatorCommandControllerBase<TKey, TEntity, TReadModel, TCreateModel, TUpdateModel>
        : MediatorQueryControllerBase<TKey, TEntity, TReadModel>
        where TEntity : class, new()
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

        protected virtual async Task<TReadModel> UpdateCommand(TKey id, TUpdateModel updateModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityUpdateCommand<TKey, TEntity, TUpdateModel, TReadModel>(id, updateModel, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }

        protected virtual async Task<TReadModel> PatchCommand(TKey id, JsonPatchDocument<TEntity> jsonPatch, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityPatchCommand<TKey, TEntity, TReadModel>(id, jsonPatch, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }

        protected virtual async Task<TReadModel> DeleteCommand(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityDeleteCommand<TKey, TEntity, TReadModel>(id, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }
    }
}