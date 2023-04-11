using System.Collections.Generic;

using Injectio.Attributes;

using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Domain;

public class EventServiceModule : DomainServiceRegistrationBase
{

    [RegisterServices]
    public override void Register(IServiceCollection services)
    {
        services.TryAddTransient<IRequestHandler<EventRangeQuery, IReadOnlyCollection<EventReadModel>>, EventRangeQueryHandler>();
    }
}
