using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Behaviors;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class UserServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.User, UserReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.User, UserReadModel, UserCreateModel, UserUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserRegisterModel>, UserReadModel>, UserRegisterCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserChangePasswordModel>, UserReadModel>, UserChangePasswordCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserForgotPasswordModel>, UserReadModel>, UserForgotPasswordCommandHandler>();
            services.TryAddTransient<IRequestHandler<UserManagementCommand<UserResetPasswordModel>, UserReadModel>, UserResetPasswordCommandHandler>();

            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserRegisterModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserRegisterModel, UserReadModel>>();
            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserChangePasswordModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserChangePasswordModel, UserReadModel>>();
            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserForgotPasswordModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserForgotPasswordModel, UserReadModel>>();
            services.AddTransient<IPipelineBehavior<UserManagementCommand<UserResetPasswordModel>, UserReadModel>, ValidateEntityModelCommandBehavior<UserResetPasswordModel, UserReadModel>>();
        }
    }
}