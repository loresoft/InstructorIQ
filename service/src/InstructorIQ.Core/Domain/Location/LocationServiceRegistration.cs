using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class LocationServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Location, LocationReadModel>(services);
            RegisterEntityCommand<Guid, Location, LocationReadModel, LocationCreateModel, LocationUpdateModel>(services);
        }
    }
}