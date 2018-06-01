using System;
using System.Collections.Generic;
using System.Text;
using KickStart.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Options
{
    public class ConfigurationServiceModule : IDependencyInjectionRegistration
    {
        public const string ConfigurationKey = "configuration";

        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            data.TryGetValue(ConfigurationKey, out var configurationData);

            if (!(configurationData is IConfiguration configuration))
                return;

            services.Configure<HostingConfiguration>(configuration.GetSection("Hosting"));
            services.Configure<PrincipalConfiguration>(configuration.GetSection("Principal"));
        }
    }
}
