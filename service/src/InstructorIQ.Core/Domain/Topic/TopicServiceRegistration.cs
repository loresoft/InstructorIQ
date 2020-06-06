using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using MediatR.CommandQuery.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MediatR.CommandQuery.Audit;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class TopicServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Topic, TopicReadModel>(services);
            RegisterEntityQuery<Guid, Topic, TopicListModel>(services);
            RegisterEntityCommand<Guid, Topic, TopicReadModel, TopicCreateModel, TopicUpdateModel>(services);

            RegisterEntityQuery<Guid, Topic, TopicMultipleUpdateModel>(services);
            RegisterEntityQuery<Guid, Topic, TopicDropdownModel>(services);

            services.TryAddTransient<IRequestHandler<TopicHistoryQuery, IReadOnlyCollection<AuditRecord<Guid>>>, TopicHistoryQueryHandler>();
            services.TryAddTransient<IRequestHandler<TopicMultipleUpdateCommand, CompleteModel>, TopicMultipleUpdateCommandHandler>();

        }
    }
}