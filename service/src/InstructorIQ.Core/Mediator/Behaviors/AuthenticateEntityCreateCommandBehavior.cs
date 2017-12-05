using System;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Data.Definitions;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Behaviors
{
    public class AuthenticateEntityCreateCommandBehavior<TEntity, TCreateModel, TReadModel> : PipelineBehaviorBase<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TCreateModel : EntityCreateModel
        where TReadModel : EntityReadModel
    {
        public AuthenticateEntityCreateCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override async Task<TReadModel> Process(EntityCreateCommand<TEntity, TCreateModel, TReadModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }

    }
}