using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Azure.Data.Tables;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;

using MediatR.CommandQuery.Handlers;

using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers;

public class LogEventQueryHandler : RequestHandlerBase<LogEventQuery, LogPagedResult>
{
    private readonly TableServiceClient _tableServiceClient;

    public LogEventQueryHandler(ILoggerFactory loggerFactory, TableServiceClient tableServiceClient) : base(loggerFactory)
    {
        _tableServiceClient = tableServiceClient;
    }

    protected override async Task<LogPagedResult> Process(LogEventQuery request, CancellationToken cancellationToken)
    {
        int pageSize = request.PageSize == 0 ? 100 : request.PageSize;

        var logTable = _tableServiceClient.GetTableClient("LogEvent");

        var dateTime = request.Date.Date.ToUniversalTime();
        var upper = $"{DateTime.MaxValue.Ticks - dateTime.Ticks:D19}";
        var lower = $"{DateTime.MaxValue.Ticks - dateTime.AddDays(1).Ticks:D19}";

        var filter = $"(PartitionKey ge '{lower}') and (PartitionKey lt '{upper}')";

        if (request.Level.HasValue())
            filter += $" and (Level eq '{request.Level}')";

        var resultPageable = logTable.QueryAsync<LogEventModel>(filter, cancellationToken: cancellationToken);

        var resultPage = await resultPageable
            .AsPages(continuationToken: request.ContinuationToken, pageSizeHint: pageSize)
            .FirstOrDefault();

        return new LogPagedResult
        {
            ContinuationToken = resultPage.ContinuationToken,
            Data = resultPage.Values.ToList()
        };

    }
}
