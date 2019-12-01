using System;
using System.Collections.Generic;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using MediatR.CommandQuery.Behaviors;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using MediatR.CommandQuery.Models;
using MediatR.CommandQuery.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class MemberServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.TryAddTransient<IRequestHandler<EntityIdentifierQuery<Guid, MemberReadModel>, MemberReadModel>, EntityIdentifierQueryHandler<InstructorIQContext, Data.Entities.User, Guid, MemberReadModel>>();
            services.TryAddTransient<IRequestHandler<EntityIdentifierQuery<Guid, MemberUpdateModel>, MemberUpdateModel>, EntityIdentifierQueryHandler<InstructorIQContext, Data.Entities.User, Guid, MemberUpdateModel>>();
            services.TryAddTransient<IRequestHandler<MemberPagedQuery, EntityPagedResult<MemberReadModel>>, MemberPagedQueryHandler>();
            services.TryAddTransient<IRequestHandler<MemberSelectQuery, IReadOnlyCollection<MemberReadModel>>, MemberSelectQueryHandler>();
            services.TryAddTransient<IRequestHandler<MemberUserNameQuery, MemberReadModel>, MemberUserNameQueryHandler>();

            services.TryAddTransient<IRequestHandler<EntityUpdateCommand<Guid, MemberUpdateModel, MemberReadModel>, MemberReadModel>, MemberUpdateCommandHandler>();
            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<Guid, MemberUpdateModel, MemberReadModel>, MemberReadModel>, ValidateEntityModelCommandBehavior<MemberUpdateModel, MemberReadModel>>();


            services.TryAddTransient<IRequestHandler<MemberChangeTenantCommand, MemberReadModel>, MemberChangeTenantCommandHandler>();
            services.TryAddTransient<IRequestHandler<MemberAssignRoleCommand, CommandCompleteModel>, MemberAssignRoleCommandHandler>();

            services.TryAddTransient<IRequestHandler<MemberImportJobQuery, MemberImportJobModel>, MemberImportJobQueryHandler>();
            services.TryAddTransient<IRequestHandler<MemberImportUploadCommand, MemberImportJobModel>, MemberImportUploadCommandHandler>();
            services.TryAddTransient<IRequestHandler<MemberImportProcessCommand, MemberImportJobModel>, MemberImportProcessCommandHandler>();
        }
    }
}
