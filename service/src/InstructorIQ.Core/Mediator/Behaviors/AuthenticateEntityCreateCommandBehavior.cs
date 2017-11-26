using System;
using System.Threading.Tasks;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Behaviors
{
    public class AuthenticateEntityCreateCommandBehavior<TEntity, TCreateModel, TReadModel> : IPipelineBehavior<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TCreateModel : EntityCreateModel
        where TReadModel : EntityReadModel
    {
        public async Task<TReadModel> Handle(EntityCreateCommand<TEntity, TCreateModel, TReadModel> request, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}