using System;
using System.Collections.Generic;
using System.Text;
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
        }
    }
}
