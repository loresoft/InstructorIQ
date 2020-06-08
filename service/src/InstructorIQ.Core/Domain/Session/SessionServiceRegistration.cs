using System;
using System.Collections.Generic;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.Models;
using Microsoft.Extensions.DependencyInjection;
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

            services.TryAddTransient<IRequestHandler<SessionTopicQuery, IReadOnlyCollection<SessionCalendarModel>>, SessionTopicQueryHandler>();
            services.TryAddTransient<IRequestHandler<SessionCalendarQuery, IReadOnlyCollection<SessionCalendarModel>>, SessionCalendarQueryHandler>();
            services.TryAddTransient<IRequestHandler<SessionInstructorQuery, IReadOnlyCollection<SessionInstructorModel>>, SessionInstructorQueryHandler>();
            services.TryAddTransient<IRequestHandler<SessionMultipleUpdateCommand, CompleteModel>, SessionMultipleUpdateCommandHandler>();
            services.TryAddTransient<IRequestHandler<SessionSequenceCreateCommand, CompleteModel>, SessionSequenceCreateCommandHandler>();
            services.TryAddTransient<IRequestHandler<SessionInstructorUpdateCommand, CompleteModel>, SessionInstructorUpdateCommandHandler>();
            services.TryAddTransient<IRequestHandler<SessionHistoryQuery, IReadOnlyCollection<AuditRecord<Guid>>>, SessionHistoryQueryHandler>();
            services.TryAddTransient<IRequestHandler<SessionInstructorHistoryQuery, IReadOnlyCollection<AuditRecord<Guid>>>, SessionInstructorHistoryQueryHandler>();
            services.TryAddTransient<IRequestHandler<SessionFrequentTimeQuery, IReadOnlyCollection<SessionFrequentTimeModel>>, SessionFrequentTimeHandler>();
        }
    }
}