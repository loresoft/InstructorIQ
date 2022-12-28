using System;

using Injectio.Attributes;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;

using MediatR;
using MediatR.CommandQuery.Models;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class EmailDeliveryServiceRegistration : DomainServiceRegistrationBase
    {

        [RegisterServices]
        public override void Register(IServiceCollection services)
        {
            RegisterEntityQuery<Guid, EmailDelivery, EmailDeliveryReadModel>(services);

            services.TryAddTransient<IRequestHandler<SendUserInviteEmailCommand, CompleteModel>, SendUserInviteEmailCommandHandler>();
            services.TryAddTransient<IRequestHandler<SendUserLinkEmailCommand, CompleteModel>, SendUserLinkEmailCommandHandler>();
            services.TryAddTransient<IRequestHandler<SendSummaryEmailCommand, CompleteModel>, SendSummaryEmailCommandHandler>();
        }
    }
}
