using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using MediatR.CommandQuery.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class EmailDeliveryServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, EmailDelivery, EmailDeliveryReadModel>(services);

            services.TryAddTransient<IRequestHandler<SendUserLinkEmailCommand, CommandCompleteModel>, SendUserLinkEmailCommandHandler>();
            services.TryAddTransient<IRequestHandler<SendSummaryEmailCommand, CommandCompleteModel>, SendSummaryEmailCommandHandler>();
        }
    }
}