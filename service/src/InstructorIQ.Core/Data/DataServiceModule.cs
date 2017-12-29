using System;
using System.Collections.Generic;
using System.Text;
using InstructorIQ.Core.Options;
using KickStart.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Data
{
    public class DataServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            data.TryGetValue(ConfigurationServiceModule.ConfigurationKey, out var configurationData);

            var configuration = configurationData as IConfiguration;
            if (configuration == null)
                return;

            var connectionString = configuration.GetConnectionString("InstructorIQ");

            services.AddDbContext<InstructorIQContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
