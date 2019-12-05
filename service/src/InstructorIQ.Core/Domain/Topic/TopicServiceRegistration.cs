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

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class TopicServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Topic, TopicReadModel>(services);
            RegisterEntityCommand<Guid, Topic, TopicReadModel, TopicCreateModel, TopicUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<TopicHistoryQuery, IReadOnlyCollection<Core.Models.HistoryRecord>>, TopicHistoryQueryHandler>();
            services.TryAddTransient<IRequestHandler<TopicCreateMultipleCommand, CommandCompleteModel>, TopicCreateMultipleCommandHandler>();

        }
    }
}