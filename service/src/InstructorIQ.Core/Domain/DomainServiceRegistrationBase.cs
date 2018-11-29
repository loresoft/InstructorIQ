using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Behaviors;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Definitions;
using EntityFrameworkCore.CommandQuery.Handlers;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Behaviors;
using InstructorIQ.Core.Data;
using KickStart.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Domain
{
    public abstract class DomainServiceRegistrationBase : IDependencyInjectionRegistration
    {
        public abstract void Register(IServiceCollection services, IDictionary<string, object> data);

        protected virtual void RegisterEntityCommand<TKey, TEntity, TReadModel, TCreateModel, TUpdateModel>(IServiceCollection services)
            where TEntity : class, IHaveIdentifier<TKey>, new()
            where TCreateModel : class
            where TUpdateModel : class
        {
            // standard crud commands
            services.TryAddTransient<IRequestHandler<EntityCreateCommand<TCreateModel, TReadModel>, TReadModel>, EntityCreateCommandHandler<InstructorIQContext, TEntity, TKey, TCreateModel, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityUpdateCommand<TKey, TUpdateModel, TReadModel>, TReadModel>, EntityUpdateCommandHandler<InstructorIQContext, TEntity, TKey, TUpdateModel, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityPatchCommand<TKey, TReadModel>, TReadModel>, EntityPatchCommandHandler<InstructorIQContext, TEntity, TKey, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityDeleteCommand<TKey, TReadModel>, TReadModel>, EntityDeleteCommandHandler<InstructorIQContext, TEntity, TKey, TReadModel>>();

            // pipeline registration,  run in order registered
            services.AddTransient<IPipelineBehavior<EntityCreateCommand<TCreateModel, TReadModel>, TReadModel>, TrackCreateCommandBehavior<TCreateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<TKey, TUpdateModel, TReadModel>, TReadModel>, TrackUpdateCommandBehavior<TKey, TUpdateModel, TReadModel>>();
            
            services.AddTransient<IPipelineBehavior<EntityCreateCommand<TCreateModel, TReadModel>, TReadModel>, AuthenticateEntityModelCommandBehavior<TCreateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<TKey, TUpdateModel, TReadModel>, TReadModel>, AuthenticateEntityModelCommandBehavior<TUpdateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityPatchCommand<TKey, TReadModel>, TReadModel>, AuthenticateEntityIdentifierCommandBehavior<TKey, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityDeleteCommand<TKey, TReadModel>, TReadModel>, AuthenticateEntityIdentifierCommandBehavior<TKey, TReadModel>>();

            services.AddTransient<IPipelineBehavior<EntityCreateCommand<TCreateModel, TReadModel>, TReadModel>, ValidateEntityModelCommandBehavior<TCreateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<TKey, TUpdateModel, TReadModel>, TReadModel>, ValidateEntityModelCommandBehavior<TUpdateModel, TReadModel>>();

            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<TKey, TUpdateModel, TReadModel>, TReadModel>, TrackChangeEntityUpdateCommandBehavior<TKey, TUpdateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityPatchCommand<TKey, TReadModel>, TReadModel>, TrackChangeEntityPatchCommandBehavior<TKey, TReadModel>>();
        }

        protected virtual void RegisterEntityQuery<TKey, TEntity, TReadModel>(IServiceCollection services)
           where TEntity : class, IHaveIdentifier<TKey>, new()
        {
            // standard queries
            services.TryAddTransient<IRequestHandler<EntityIdentifierQuery<TKey, TReadModel>, TReadModel>, EntityIdentifierQueryHandler<InstructorIQContext, TEntity, TKey, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityListQuery<TReadModel>, EntityListResult<TReadModel>>, EntityListQueryHandler<InstructorIQContext, TEntity, TReadModel>>();
        }

    }
}
