using System;
using System.Collections.Generic;
using System.Text;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Options;
using InstructorIQ.Core.Tests.Logger;
using InstructorIQ.Core.Tests.Samples;
using KickStart;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests
{
    public abstract class DependencyInjectionBase : UnitTestBase
    {

        protected DependencyInjectionBase(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddSingleton(p => configuration);
            services.AddLogging(log => log.AddXunit(OutputHelper, Microsoft.Extensions.Logging.LogLevel.Trace));
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
    }
}
