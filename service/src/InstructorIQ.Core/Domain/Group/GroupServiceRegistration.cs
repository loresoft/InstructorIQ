using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class GroupServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Group, GroupReadModel>(services);
            RegisterEntityCommand<Guid, Group, GroupReadModel, GroupCreateModel, GroupUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<GroupDropdownQuery, IReadOnlyCollection<GroupDropdownModel>>, GroupDropdownQueryHandler>();
            services.TryAddTransient<IRequestHandler<GroupSequenceQuery, IReadOnlyCollection<GroupSequenceModel>>, GroupSequenceQueryHandler>();
        }
    }
}