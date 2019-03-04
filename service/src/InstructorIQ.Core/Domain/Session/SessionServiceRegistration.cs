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
    public class SessionServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Session, SessionReadModel>(services);
            RegisterEntityCommand<Guid, Session, SessionReadModel, SessionCreateModel, SessionUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<TopicSessionQuery, IReadOnlyCollection<SessionReadModel>>, TopicSessionQueryHandler>();
        }
    }
}