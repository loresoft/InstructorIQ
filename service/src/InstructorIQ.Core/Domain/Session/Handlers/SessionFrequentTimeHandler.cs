using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FluentCommand;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR.CommandQuery.Handlers;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers;

public class SessionFrequentTimeHandler : RequestHandlerBase<SessionFrequentTimeQuery, IReadOnlyCollection<SessionFrequentTimeModel>>
{
    private readonly IDataSession _dataSession;

    public SessionFrequentTimeHandler(ILoggerFactory loggerFactory, IDataSession dataSession)
        : base(loggerFactory)
    {
        _dataSession = dataSession;
    }

    protected override async Task<IReadOnlyCollection<SessionFrequentTimeModel>> Process(SessionFrequentTimeQuery request, CancellationToken cancellationToken)
    {
        var results = await _dataSession
            .StoredProcedure("[IQ].[FrequentSessionTimes]")
            .Parameter("@tenantId", request.TenantId)
            .QueryAsync(r =>
            {
                var reader = r as SqlDataReader;
                return new SessionFrequentTimeModel
                {
                    StartTime = reader.GetTimeSpan(0),
                    EndTime = reader.GetTimeSpan(1),
                    Count = r.GetInt32(2)
                };
            }, cancellationToken);

        return results.ToList();
    }
}
