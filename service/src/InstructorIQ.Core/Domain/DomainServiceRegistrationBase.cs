using InstructorIQ.Core.Behaviors;
using InstructorIQ.Core.Data;

using MediatR;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Domain
{
    public abstract class DomainServiceRegistrationBase
    {

        public abstract void Register(IServiceCollection services);

        protected virtual void RegisterEntityCommand<TKey, TEntity, TReadModel, TCreateModel, TUpdateModel>(IServiceCollection services)
            where TEntity : class, IHaveIdentifier<TKey>, new()
            where TCreateModel : class
            where TUpdateModel : class
        {
            services.AddEntityCommands<InstructorIQContext, TEntity, TKey, TReadModel, TCreateModel, TUpdateModel>();

            services.AddTransient<IPipelineBehavior<EntityPatchCommand<TKey, TReadModel>, TReadModel>, AuthenticateEntityIdentifierCommandBehavior<TKey, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityDeleteCommand<TKey, TReadModel>, TReadModel>, AuthenticateEntityIdentifierCommandBehavior<TKey, TReadModel>>();

            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<TKey, TUpdateModel, TReadModel>, TReadModel>, TrackChangeEntityUpdateCommandBehavior<TKey, TUpdateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityPatchCommand<TKey, TReadModel>, TReadModel>, TrackChangeEntityPatchCommandBehavior<TKey, TReadModel>>();
        }

        protected virtual void RegisterEntityQuery<TKey, TEntity, TReadModel>(IServiceCollection services)
           where TEntity : class, IHaveIdentifier<TKey>, new()
           where TReadModel : class
        {
            services.AddEntityQueries<InstructorIQContext, TEntity, TKey, TReadModel>();
        }

    }
}
