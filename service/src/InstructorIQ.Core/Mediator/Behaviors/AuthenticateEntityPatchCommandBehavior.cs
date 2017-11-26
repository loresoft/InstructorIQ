using System;
using System.Threading.Tasks;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Behaviors
{
    public class AuthenticateEntityPatchCommandBehavior<TEntity, TReadModel> : IPipelineBehavior<EntityPatchCommand<TEntity, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        public async Task<TReadModel> Handle(EntityPatchCommand<TEntity, TReadModel> request, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}