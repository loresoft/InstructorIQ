using System;
using System.Collections.Generic;

using Injectio.Attributes;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR;
using MediatR.CommandQuery.EntityFrameworkCore;
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

        [RegisterServices]
        public override void Register(IServiceCollection services)
        {
            services.TryAddTransient<IRequestHandler<EntityIdentifierQuery<Guid, MemberReadModel>, MemberReadModel>, EntityIdentifierQueryHandler<InstructorIQContext, Data.Entities.User, Guid, MemberReadModel>>();
            services.TryAddTransient<IRequestHandler<MemberPagedQuery, EntityPagedResult<MemberReadModel>>, MemberPagedQueryHandler>();
            services.TryAddTransient<IRequestHandler<MemberSelectQuery, IReadOnlyCollection<MemberReadModel>>, MemberSelectQueryHandler>();
            services.TryAddTransient<IRequestHandler<MemberDropdownQuery, IReadOnlyCollection<MemberDropdownModel>>, MemberDropdownQueryHandler>();
            services.TryAddTransient<IRequestHandler<MemberUserNameQuery, MemberReadModel>, MemberUserNameQueryHandler>();

            services.AddEntityUpdateCommand<InstructorIQContext, Data.Entities.User, Guid, MemberReadModel, MemberUpdateModel>();

            services.TryAddTransient<IRequestHandler<MemberChangeTenantCommand, MemberReadModel>, MemberChangeTenantCommandHandler>();
            services.TryAddTransient<IRequestHandler<MemberAssignRoleCommand, CompleteModel>, MemberAssignRoleCommandHandler>();

            services.TryAddTransient<IRequestHandler<MemberImportJobQuery, MemberImportJobModel>, MemberImportJobQueryHandler>();
            services.TryAddTransient<IRequestHandler<MemberImportUploadCommand, MemberImportJobModel>, MemberImportUploadCommandHandler>();
            services.TryAddTransient<IRequestHandler<MemberImportProcessCommand, MemberImportJobModel>, MemberImportProcessCommandHandler>();
        }
    }
}
