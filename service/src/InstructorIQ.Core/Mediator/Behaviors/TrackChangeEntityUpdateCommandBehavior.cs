using System;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Behaviors
{
    public class TrackChangeEntityUpdateCommandBehavior<TEntity, TUpdateModel, TReadModel> : PipelineBehaviorBase<EntityUpdateCommand<TEntity, TUpdateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TUpdateModel : EntityUpdateModel
        where TReadModel : EntityReadModel
    {
        public TrackChangeEntityUpdateCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override async Task<TReadModel> Process(EntityUpdateCommand<TEntity, TUpdateModel, TReadModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}