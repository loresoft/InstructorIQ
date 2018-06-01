using System;
using System.Collections.Generic;
using AutoMapper;
using KickStart.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Domain
{
    public class MapperServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.AddSingleton(p => Mapper.Instance);
        }
    }
}
