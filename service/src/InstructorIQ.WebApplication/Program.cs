using System;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace InstructorIQ.WebApplication
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            // azure home directory
            var homeDirectory = Environment.GetEnvironmentVariable("HOME") ?? ".";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss.fff} [{Level:u1}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(
                    path: $"{homeDirectory}/LogFiles/WebApplication/log.txt",
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1),
                    outputTemplate: "{Timestamp:HH:mm:ss.fff} [{Level:u1}] {Message:lj}{NewLine}{Exception}",
                    retainedFileCountLimit: 10
                )
                .WriteTo.File(
                    formatter: new CompactJsonFormatter(),
                    path: $"{homeDirectory}/LogFiles/WebApplication/log.clef",
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1),
                    retainedFileCountLimit: 30
                )
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
