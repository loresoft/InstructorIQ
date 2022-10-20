using FluentCommand;

using Injectio.Attributes;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Data
{
    public class DataServiceModule
    {

        [RegisterServices]
        public void Register(IServiceCollection services)
        {
            services.AddDbContextPool<InstructorIQContext>((provider, options) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("InstructorIQ");
                options.UseSqlServer(connectionString, providerOptions => providerOptions.EnableRetryOnFailure());
            });

            services.TryAddSingleton<IDataConfiguration>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("InstructorIQ");
                return new DataConfiguration(SqlClientFactory.Instance, connectionString);
            });

            services.TryAddTransient<IDataSession, DataSession>();
        }
    }
}
