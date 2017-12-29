using System;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.Web.Controllers
{
    public abstract class MediatorQueryControllerBase<TEntity, TReadModel> : Controller
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        protected MediatorQueryControllerBase(IMediator mediator)
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
    }
}