using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Jobs;

public abstract class OneTimeJobBase : IOneTimeJob
{
    protected OneTimeJobBase(ILoggerFactory loggerFactory)
    {
        Logger = loggerFactory.CreateLogger(GetType());
    }

    protected ILogger Logger { get; }

    public abstract Guid Id { get; }

    public virtual async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var jobType = GetType().Name;

        try
        {
            Logger.LogTrace("Processing one-time job '{jobType}' ...", jobType);
            var watch = Stopwatch.StartNew();

            await ProcessAsync(cancellationToken).ConfigureAwait(false);

            watch.Stop();
            Logger.LogTrace("Processed one-time job '{jobType}': {elapsed} ms", jobType, watch.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error processing one-time job '{jobType}': {errorMessage}", jobType, ex.Message);
            throw;
        }
    }

    public abstract Task ProcessAsync(CancellationToken cancellationToken);
}
