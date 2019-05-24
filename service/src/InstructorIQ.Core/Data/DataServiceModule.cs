using System.Collections.Generic;
using System.Data.SqlClient;
using FluentCommand;
using InstructorIQ.Core.Options;
using KickStart.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Data
{
    public class DataServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            data.TryGetValue(ConfigurationServiceModule.ConfigurationKey, out var configurationData);

            if (!(configurationData is IConfiguration configuration))
                return;

            var connectionString = configuration.GetConnectionString("InstructorIQ");

            services.AddDbContext<InstructorIQContext>(options => options
                .UseSqlServer(connectionString)
            );

            services.TryAddSingleton<IDataConfiguration>(s => new DataConfiguration(SqlClientFactory.Instance, connectionString));
            services.TryAddTransient<IDataSession, DataSession>();
        }
    }
}
