using System;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace InstructorIQ.WebApplication
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Debug()
                .WriteTo.LiterateConsole()
                .WriteTo.RollingFile("log-{Date}.txt", LogEventLevel.Debug)
                .WriteTo.ApplicationInsights(TelemetryConfiguration.CreateDefault(), TelemetryConverter.Traces)
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");

                var host = Host
                    .CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                    .UseSerilog()
                    .Build();

                host.Run();

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
