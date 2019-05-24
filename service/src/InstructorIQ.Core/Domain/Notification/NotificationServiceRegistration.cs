using System;
using System.Collections.Generic;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class NotificationServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Notification, NotificationReadModel>(services);
            RegisterEntityCommand<Guid, Notification, NotificationReadModel, NotificationCreateModel, NotificationUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<NotificationUnreadQuery, NotificationUnreadModel>, NotificationUnreadQueryHandler>();
        }
    }
}
