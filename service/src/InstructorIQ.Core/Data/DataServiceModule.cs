using FluentCommand;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Data;

public class DataServiceModule
{

    [RegisterServices]
    public void Register(IServiceCollection services)
    {
        services.AddDbContext<InstructorIQContext>((provider, options) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("InstructorIQ");
            options.UseSqlServer(connectionString, providerOptions => providerOptions.EnableRetryOnFailure());
        }, ServiceLifetime.Transient);

        services.TryAddSingleton<IDataConfiguration>(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("InstructorIQ");
            return new DataConfiguration(SqlClientFactory.Instance, connectionString);
        });

        services.TryAddTransient<IDataSession, DataSession>();
    }
}
