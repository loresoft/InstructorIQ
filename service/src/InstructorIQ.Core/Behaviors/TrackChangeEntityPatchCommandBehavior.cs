using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Behaviors;
using EntityFrameworkCore.CommandQuery.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Behaviors
{
    public class TrackChangeEntityPatchCommandBehavior<TKey, TEntity, TReadModel> : PipelineBehaviorBase<EntityPatchCommand<TKey, TEntity, TReadModel>, TReadModel>
        where TEntity : class, new()
    {
        public TrackChangeEntityPatchCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override async Task<TReadModel> Process(EntityPatchCommand<TKey, TEntity, TReadModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }

    }
}