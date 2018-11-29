using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Behaviors;
using EntityFrameworkCore.CommandQuery.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Behaviors
{
    public class TrackChangeEntityUpdateCommandBehavior<TKey, TUpdateModel, TReadModel>
        : PipelineBehaviorBase<EntityUpdateCommand<TKey, TUpdateModel, TReadModel>, TReadModel>
    {
        public TrackChangeEntityUpdateCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override async Task<TReadModel> Process(EntityUpdateCommand<TKey, TUpdateModel, TReadModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}