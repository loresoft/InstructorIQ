using System.Threading;
using System.Threading.Tasks;

using MediatR;
using MediatR.CommandQuery.Behaviors;
using MediatR.CommandQuery.Commands;

using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Behaviors
{
    public class TrackChangeEntityUpdateCommandBehavior<TKey, TUpdateModel, TReadModel>
        : PipelineBehaviorBase<EntityUpdateCommand<TKey, TUpdateModel, TReadModel>, TReadModel>
    {
        public TrackChangeEntityUpdateCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override async Task<TReadModel> Process(EntityUpdateCommand<TKey, TUpdateModel, TReadModel> request, RequestHandlerDelegate<TReadModel> next, CancellationToken cancellationToken)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}
