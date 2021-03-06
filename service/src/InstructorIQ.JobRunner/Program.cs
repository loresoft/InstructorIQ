﻿using System;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Options;
using KickStart;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace InstructorIQ.JobRunner
{
    public static class Program
    {
        static async Task<int> Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("log.txt", LogEventLevel.Debug, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Starting JobRunner host");

                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

                var host = new HostBuilder()
                    .UseEnvironment(environment)
                    .ConfigureHostConfiguration((config) =>
                    {
                        config.AddEnvironmentVariables();
                    })
                    .ConfigureAppConfiguration((hostContext, builder) =>
                    {
                        builder
                            .AddJsonFile("appsettings.json")
                            .AddJsonFile($"appsettings.{hostContext.HostingEnvironment}.json", true)
                            .AddEnvironmentVariables();

                        if (hostContext.HostingEnvironment.IsDevelopment())
                        {
                            builder.AddUserSecrets("903022c7-65a9-40cf-8939-9a3388f50b0f");
                        }
                    })
                    .ConfigureServices((hostContext, services) =>
                    {
                        var connectionString = hostContext.Configuration.GetConnectionString("InstructorIQ");

                        services.AddOptions();
                        services.AddSingleton(p => hostContext.Configuration);

                        services.KickStart(config => config
                            .IncludeAssemblyFor<InstructorIQContext>()
                            .Data(ConfigurationServiceModule.ConfigurationKey, hostContext.Configuration)
                            .Data("hostProcess", "runner")
                            .UseStartupTask()
                        );

                        services.Configure<HostOptions>(option =>
                        {
                            option.ShutdownTimeout = TimeSpan.FromSeconds(60);
                        });

                        // hangfire options
                        services.TryAddSingleton(new SqlServerStorageOptions());
                        services.TryAddSingleton(new BackgroundJobServerOptions
                        {
                            StopTimeout = TimeSpan.FromSeconds(15),
                            ShutdownTimeout = TimeSpan.FromSeconds(30),
                            WorkerCount = hostContext.HostingEnvironment.IsDevelopment() ? 1 : 4
                        });

                        services.AddHangfire((provider, configuration) => configuration
                            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                            .UseSimpleAssemblyNameTypeSerializer()
                            .UseSqlServerStorage(
                                connectionString,
                                provider.GetRequiredService<SqlServerStorageOptions>())
                            );

                        services.AddHostedService<RecurringJobsService>();
                        services.AddHostedService<OneTimeJobService>();
                        services.AddHangfireServer();
                    })
                    .UseSerilog();


                await host.RunConsoleAsync();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
