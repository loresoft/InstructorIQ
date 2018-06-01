using System.Collections.Generic;
using KickStart.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Domain
{
    public class MediatorServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.AddScoped<SingleInstanceFactory>(p => p.GetService);
            services.AddScoped<MultiInstanceFactory>(p => p.GetServices);
            services.AddScoped<IMediator, MediatR.Mediator>();
        }
    }
}
