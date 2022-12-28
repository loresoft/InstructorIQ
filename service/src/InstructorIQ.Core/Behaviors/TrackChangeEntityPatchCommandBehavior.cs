using System.Threading;
using System.Threading.Tasks;

using MediatR;
using MediatR.CommandQuery.Behaviors;
using MediatR.CommandQuery.Commands;

using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Behaviors
{
    public class TrackChangeEntityPatchCommandBehavior<TKey, TReadModel>
        : PipelineBehaviorBase<EntityPatchCommand<TKey, TReadModel>, TReadModel>
    {
        public TrackChangeEntityPatchCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override async Task<TReadModel> Process(EntityPatchCommand<TKey, TReadModel> request, RequestHandlerDelegate<TReadModel> next, CancellationToken cancellationToken)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }

    }
}
