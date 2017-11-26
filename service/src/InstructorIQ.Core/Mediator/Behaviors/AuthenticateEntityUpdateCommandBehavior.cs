using System;
using System.Threading.Tasks;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Behaviors
{
    public class AuthenticateEntityUpdateCommandBehavior<TEntity, TUpdateModel, TReadModel> : IPipelineBehavior<EntityUpdateCommand<TEntity, TUpdateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TUpdateModel : EntityUpdateModel
        where TReadModel : EntityReadModel
    {
        public async Task<TReadModel> Handle(EntityUpdateCommand<TEntity, TUpdateModel, TReadModel> request, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}