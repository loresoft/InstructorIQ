using System;
using System.Collections.Generic;

using Injectio.Attributes;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain;

public class LocationServiceRegistration : DomainServiceRegistrationBase
{

    [RegisterServices]
    public override void Register(IServiceCollection services)
    {
        RegisterEntityQuery<Guid, Location, LocationReadModel>(services);
        RegisterEntityCommand<Guid, Location, LocationReadModel, LocationCreateModel, LocationUpdateModel>(services);

        services.TryAddTransient<IRequestHandler<LocationDropdownQuery, IReadOnlyCollection<LocationDropdownModel>>, LocationDropdownQueryHandler>();
    }
}
