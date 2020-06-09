using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using InstructorIQ.Core.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.JobRunner
{
    internal class RecurringJobsService : BackgroundService
    {
        private readonly ILogger<RecurringJobsService> _logger;

        public RecurringJobsService(ILogger<RecurringJobsService> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                RecurringJob.AddOrUpdate<IEmailDeliveryService>(
                    emailService => emailService.ProcessEmailQueueAsync(CancellationToken.None),
                    Cron.Minutely);

                RecurringJob.AddOrUpdate<ICleanupService>(
                    emailService => emailService.ProcessAsync(CancellationToken.None),
                    Cron.Daily);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating recurring jobs: {message}", ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}
