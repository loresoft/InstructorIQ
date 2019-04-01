using System;
using System.Collections.Generic;
using AutoMapper;
using EntityFrameworkCore.CommandQuery;
using KickStart.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Domain
{
    public class CommandQueryServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.AddCommandQueryForAssembly<CommandQueryServiceModule>();
        }
    }
}
