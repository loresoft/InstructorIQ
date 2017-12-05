using System;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Behaviors
{
    public class TrackChangeEntityPatchCommandBehavior<TEntity, TReadModel> : PipelineBehaviorBase<EntityPatchCommand<TEntity, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        public TrackChangeEntityPatchCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override async Task<TReadModel> Process(EntityPatchCommand<TEntity, TReadModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }

    }
}