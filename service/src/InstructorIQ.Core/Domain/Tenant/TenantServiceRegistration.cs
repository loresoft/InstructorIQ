using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Behaviors;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class TenantServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Tenant, TenantReadModel>(services);
            RegisterEntityCommand<Guid, Tenant, TenantReadModel, TenantCreateModel, TenantUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<TenantUserResolveCommand, TenantUserModel>, TenantUserResolveCommandHandler>();

            services.TryAddTransient<IRequestHandler<TenantSlugQuery, TenantReadModel>, TenantSlugQueryHandler>();
            services.AddTransient<IPipelineBehavior<TenantSlugQuery, TenantReadModel>, MemoryCacheQueryBehavior<TenantSlugQuery, TenantReadModel>>();

            services.TryAddTransient<IRequestHandler<TenantDropdownQuery, IReadOnlyCollection<TenantDropdownModel>>, TenantDropdownQueryHandler>();

            services.TryAddTransient<IRequestHandler<TenantMembershipQuery, TenantMembershipModel>, TenantMembershipQueryHandler>();
            services.TryAddTransient<IRequestHandler<TenantMembershipCommand, TenantMembershipModel>, TenantMembershipCommandHandler>();

        }
    }
}