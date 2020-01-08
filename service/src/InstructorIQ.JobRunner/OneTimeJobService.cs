using System;
using System.Threading;
using System.Threading.Tasks;
using FluentCommand;
using InstructorIQ.Core.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.JobRunner
{
    internal class OneTimeJobService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDataSession _dataSession;
        private readonly ILogger<OneTimeJobService> _logger;

        public OneTimeJobService(IServiceProvider serviceProvider, IDataSession dataSession, ILogger<OneTimeJobService> logger)
        {
            _serviceProvider = serviceProvider;
            _dataSession = dataSession;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Running Background Service {serviceName}", nameof(OneTimeJobService));
            var jobs = _serviceProvider.GetServices<IOneTimeJob>();


            foreach (var job in jobs) 
                await ProcessAsync(job, cancellationToken);
        }

        private async Task ProcessAsync(IOneTimeJob job, CancellationToken cancellationToken)
        {
            if (await HasRun(job, cancellationToken))
                return;

            await job.ExecuteAsync(cancellationToken);

            await MarkDone(job, cancellationToken);
        }

        private async Task MarkDone(IOneTimeJob job, CancellationToken cancellationToken)
        {
            var jobType = job.GetType().Name;

            var sql = "INSERT [dbo].[Datasweep] ([Id], [Description]) VALUES (@id, @description)";
            
            var result = await _dataSession.Sql(sql)
                .Parameter("@id", job.Id)
                .Parameter("@description", $"One-Time Job {jobType}")
                .ExecuteAsync(cancellationToken);
        }

        private async Task<bool> HasRun(IOneTimeJob job, CancellationToken cancellationToken)
        {
            var sql = "SELECT COUNT([Id]) AS Count FROM [dbo].[Datasweep] WHERE [Id] = @id";
            
            var count = await _dataSession.Sql(sql)
                .Parameter("@id", job.Id)
                .QueryValueAsync<int>(cancellationToken);

            return count > 0;
        }
    }
}