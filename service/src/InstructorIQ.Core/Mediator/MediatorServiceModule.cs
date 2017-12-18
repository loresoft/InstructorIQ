using System;
using System.Collections.Generic;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Behaviors;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Handlers;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Mediator.Queries;
using InstructorIQ.Core.Security;
using KickStart.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Mediator
{
    public class MediatorServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            #region Generated Registrations
            RegisterEntity<Organization, OrganizationReadModel, OrganizationCreateModel, OrganizationUpdateModel>(services);
            RegisterEntity<EmailTemplate, EmailTemplateReadModel, EmailTemplateCreateModel, EmailTemplateUpdateModel>(services);
            RegisterEntity<Group, GroupReadModel, GroupCreateModel, GroupUpdateModel>(services);
            RegisterEntity<Instructor, InstructorReadModel, InstructorCreateModel, InstructorUpdateModel>(services);
            RegisterEntity<User, UserReadModel, UserCreateModel, UserUpdateModel>(services);
            RegisterEntity<InstructorOrganization, InstructorOrganizationReadModel, InstructorOrganizationCreateModel, InstructorOrganizationUpdateModel>(services);
            RegisterEntity<Location, LocationReadModel, LocationCreateModel, LocationUpdateModel>(services);
            RegisterEntity<Session, SessionReadModel, SessionCreateModel, SessionUpdateModel>(services);
            RegisterEntity<Topic, TopicReadModel, TopicCreateModel, TopicUpdateModel>(services);
            RegisterEntity<SessionGroup, SessionGroupReadModel, SessionGroupCreateModel, SessionGroupUpdateModel>(services);
            RegisterEntity<SessionInstructor, SessionInstructorReadModel, SessionInstructorCreateModel, SessionInstructorUpdateModel>(services);

            #endregion

            // read only models
            RegisterEntityRead<EmailDelivery, EmailDeliveryReadModel>(services);
            RegisterEntityRead<UserLoginHistory, UserLoginHistoryReadModel>(services);

            RegisterUserManagement(services);

            services.AddScoped<SingleInstanceFactory>(p => p.GetService);
            services.AddScoped<MultiInstanceFactory>(p => p.GetServices);
            services.AddScoped<IMediator, MediatR.Mediator>();
        }

        private static void RegisterUserManagement(IServiceCollection services)
        {
            services.TryAddTransient<IRequestHandler<AuthenticateCommand, TokenResponse>, AuthenticateCommandHandler>();

            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserRegisterModel>, UserReadModel>, UserRegisterCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserChangePasswordModel>, UserReadModel>, UserChangePasswordCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserForgotPasswordModel>, UserReadModel>, UserForgotPasswordCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserResetPasswordModel>, UserReadModel>, UserResetPasswordCommandHandler>();

            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserRegisterModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserRegisterModel, UserReadModel>>();
            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserChangePasswordModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserChangePasswordModel, UserReadModel>>();
            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserForgotPasswordModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserForgotPasswordModel, UserReadModel>>();
            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserResetPasswordModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserResetPasswordModel, UserReadModel>>();
        }


        public void RegisterEntity<TEntity, TReadModel, TCreateModel, TUpdateModel>(IServiceCollection services)
            where TEntity : class, new()
            where TReadModel : EntityReadModel
            where TCreateModel : EntityCreateModel
            where TUpdateModel : EntityUpdateModel
        {
            RegisterEntityRead<TEntity, TReadModel>(services);

            // standard crud commands
            services.TryAddTransient<IRequestHandler<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>, EntityCreateCommandHandler<TEntity, TCreateModel, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityUpdateCommand<TEntity, TUpdateModel, TReadModel>, TReadModel>, EntityUpdateCommandHandler<TEntity, TUpdateModel, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityPatchCommand<TEntity, TReadModel>, TReadModel>, EntityPatchCommandHandler<TEntity, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityDeleteCommand<TEntity, TReadModel>, TReadModel>, EntityDeleteCommandHandler<TEntity, TReadModel>>();

            // pipeline registration,  run in order registered
            services.AddTransient<IPipelineBehavior<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>, AuthenticateEntityCreateCommandBehavior<TEntity, TCreateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<TEntity, TUpdateModel, TReadModel>, TReadModel>, AuthenticateEntityUpdateCommandBehavior<TEntity, TUpdateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityPatchCommand<TEntity, TReadModel>, TReadModel>, AuthenticateEntityPatchCommandBehavior<TEntity, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityDeleteCommand<TEntity, TReadModel>, TReadModel>, AuthenticateEntityDeleteCommandBehavior<TEntity, TReadModel>>();

            services.AddTransient<IPipelineBehavior<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>, ValidateEntityModelCommandBehavior<TCreateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<TEntity, TUpdateModel, TReadModel>, TReadModel>, ValidateEntityModelCommandBehavior<TUpdateModel, TReadModel>>();

            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<TEntity, TUpdateModel, TReadModel>, TReadModel>, TrackChangeEntityUpdateCommandBehavior<TEntity, TUpdateModel, TReadModel>>();
            services.AddTransient<IPipelineBehavior<EntityPatchCommand<TEntity, TReadModel>, TReadModel>, TrackChangeEntityPatchCommandBehavior<TEntity, TReadModel>>();
        }

        public void RegisterEntityRead<TEntity, TReadModel>(IServiceCollection services)
           where TEntity : class, new()
           where TReadModel : EntityReadModel
        {
            // standard queries
            services.TryAddTransient<IRequestHandler<EntityIdentifierQuery<TEntity, TReadModel>, TReadModel>, EntityIdentifierQueryHandler<TEntity, TReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityListQuery<TEntity, TReadModel>, EntityListResult<TReadModel>>, EntityListQueryHandler<TEntity, TReadModel>>();
        }
    }
}
