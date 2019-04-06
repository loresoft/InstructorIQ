using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Behaviors;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Handlers;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Domain
{
    public class MemberServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.TryAddTransient<IRequestHandler<EntityIdentifierQuery<Guid, MemberUpdateModel>, MemberUpdateModel>, EntityIdentifierQueryHandler<InstructorIQContext, Data.Entities.User, Guid, MemberUpdateModel>>();
            services.TryAddTransient<IRequestHandler<MemberPagedQuery, EntityPagedResult<MemberReadModel>>, MemberPagedQueryHandler>();

            services.TryAddTransient<IRequestHandler<EntityUpdateCommand<Guid, MemberUpdateModel, MemberReadModel>, MemberReadModel>, MemberUpdateCommandHandler>();
            services.AddTransient<IPipelineBehavior<EntityUpdateCommand<Guid, MemberUpdateModel, MemberReadModel>, MemberReadModel>, ValidateEntityModelCommandBehavior<MemberUpdateModel, MemberReadModel>>();
        }
    }
}
