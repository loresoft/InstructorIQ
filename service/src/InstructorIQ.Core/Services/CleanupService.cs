using System.Threading;
using System.Threading.Tasks;

using FluentCommand;

using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Services;

public class CleanupService : ICleanupService
{
    private readonly ILogger<CleanupService> _logger;
    private readonly IDataSession _dataSession;

    public CleanupService(ILogger<CleanupService> logger, IDataSession dataSession)
    {
        _logger = logger;
        _dataSession = dataSession;
    }

    public async Task ProcessAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogTrace("Processing cleanup job");

        await _dataSession
            .StoredProcedure("[Log].[PurgeLogs]")
            .Parameter("@daysToKeep", 30)
            .ExecuteAsync(cancellationToken);

        await _dataSession
            .StoredProcedure("[IQ].[PurgeEmailDelivery]")
            .Parameter("@daysToKeep", 90)
            .ExecuteAsync(cancellationToken);

        _logger.LogTrace("Completed cleanup job");
    }
}
