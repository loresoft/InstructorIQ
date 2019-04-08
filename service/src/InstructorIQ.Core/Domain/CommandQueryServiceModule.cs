using System.Collections.Generic;
using InstructorIQ.Core.Data;
using KickStart.DependencyInjection;
using MediatR.CommandQuery.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Domain
{
    public class CommandQueryServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.AddMediator();
            services.AddMapper();
            services.AddValidatorsFromAssembly<InstructorIQContext>();
        }
    }
}
