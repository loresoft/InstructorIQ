using System.Collections.Generic;
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
            services
                .AddOptions<StorageConfiguration>()
                .Configure<IConfiguration>((settings, configuration) => configuration
                    .GetSection(StorageConfiguration.ConfigurationName)
                    .Bind(settings)
                );

            services
                .AddOptions<SendGridConfiguration>()
                .Configure<IConfiguration>((settings, configuration) => configuration
                    .GetSection(SendGridConfiguration.ConfigurationName)
                    .Bind(settings)
                );

            services
                .AddOptions<SecurityOptions>()
                .Configure<IConfiguration>((settings, configuration) => configuration
                    .GetSection(SecurityOptions.ConfigurationName)
                    .Bind(settings)
                );

        }
    }
}
