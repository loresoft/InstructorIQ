using System;
using System.Collections.Generic;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using MediatR.CommandQuery.Audit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class DiscussionServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Discussion, DiscussionReadModel>(services);
            RegisterEntityCommand<Guid, Discussion, DiscussionReadModel, DiscussionCreateModel, DiscussionUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<DiscussionTopicQuery, IReadOnlyCollection<DiscussionReadModel>>, DiscussionTopicQueryHandler>();
            services.TryAddTransient<IRequestHandler<DiscussionHistoryQuery, IReadOnlyCollection<AuditRecord<Guid>>>, DiscussionHistoryQueryHandler>();

        }
    }
}
