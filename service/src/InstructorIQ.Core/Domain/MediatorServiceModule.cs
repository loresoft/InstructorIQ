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
            services.AddScoped<MediatR.ServiceFactory>(p => p.GetService);
            services.AddScoped<IMediator, MediatR.Mediator>();
        }
    }
}
