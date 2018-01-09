using System;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Options;
using InstructorIQ.Core.Tests.Samples;
using KickStart;
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

            services.KickStart(config => config
                .IncludeAssemblyFor<InstructorIQContext>()
                .IncludeAssemblyFor<Fruit>()
                .Data(ConfigurationServiceModule.ConfigurationKey, configuration)
                .Data("hostProcess", "test")
                .UseAutoMapper()
                .UseStartupTask()
            );
        }

        public IServiceProvider ServiceProvider => Kick.ServiceProvider;

        public void Dispose()
        {

        }
    }
}