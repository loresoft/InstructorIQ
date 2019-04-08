using System;
using System.Collections.Generic;
using MediatR.CommandQuery.Definitions;
using KickStart.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Services
{
    public class RegisterServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.TryAddScoped<IEmailTemplateService, EmailTemplateService>();
            services.TryAddScoped<IEmailDeliveryService, EmailDeliveryService>();
            services.TryAddScoped<ITenantResolver<Guid>, TenantResolver>();
        }
    }
}
