using System.Threading;
using System.Threading.Tasks;

using MediatR;
using MediatR.CommandQuery.Behaviors;
using MediatR.CommandQuery.Commands;

using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Behaviors;

public class AuthenticateEntityIdentifierCommandBehavior<TKey, TReadModel>
    : PipelineBehaviorBase<EntityIdentifierCommand<TKey, TReadModel>, TReadModel>
{
    public AuthenticateEntityIdentifierCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
    {
    }

    protected override async Task<TReadModel> Process(EntityIdentifierCommand<TKey, TReadModel> request, RequestHandlerDelegate<TReadModel> next, CancellationToken cancellationToken)
    {
        // continue pipeline
        return await next().ConfigureAwait(false);
    }
}
