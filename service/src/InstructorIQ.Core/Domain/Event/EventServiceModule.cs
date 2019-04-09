using System.Collections.Generic;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Domain
{
    public class EventServiceModule : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.TryAddTransient<IRequestHandler<EventRangeQuery, IReadOnlyCollection<EventReadModel>>, EventRangeQueryHandler>();
        }
    }
}
