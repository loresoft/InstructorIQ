using System;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Behaviors
{
    public class AuthenticateEntityIdentifierCommandBehavior<TReadModel> : PipelineBehaviorBase<EntityIdentifierCommand<TReadModel>, TReadModel>
        where TReadModel : EntityReadModel
    {
        public AuthenticateEntityIdentifierCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override async Task<TReadModel> Process(EntityIdentifierCommand<TReadModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}