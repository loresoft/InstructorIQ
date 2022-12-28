using System;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Tests
{
    public class DependencyInjectionFixture : IDisposable
    {
        public DependencyInjectionFixture()
        {
            var enviromentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Test";
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{enviromentName}.json", true);

            var configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddSingleton(p => configuration);
            services.AddLogging();
            services.AddOptions();

            services.AddTransient<ITenant<TenantReadModel>>(provider => new TenantValue<TenantReadModel>(new TenantReadModel
            {
                Id = Data.Constants.Tenant.Test,
                Slug = "Test",
                Name = "Test"
            }));

            services.AddInstructorIQCore();

            ServiceProvider = services.BuildServiceProvider();

        }

        public IServiceProvider ServiceProvider { get; }

        public void Dispose()
        {
        }
    }
}
