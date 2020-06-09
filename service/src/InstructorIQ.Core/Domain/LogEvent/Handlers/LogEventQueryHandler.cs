using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentCommand;
using FluentCommand.Extensions;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR.CommandQuery.Handlers;
using MediatR.CommandQuery.Queries;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers
{
    public class LogEventQueryHandler : RequestHandlerBase<LogEventQuery, EntityPagedResult<LogEventModel>>
    {
        private readonly IDataSession _dataSession;

        public LogEventQueryHandler(ILoggerFactory loggerFactory, IDataSession dataSession) : base(loggerFactory)
        {
            _dataSession = dataSession;
        }

        protected override async Task<EntityPagedResult<LogEventModel>> Process(LogEventQuery request, CancellationToken cancellationToken)
        {
            int page = request.Page == 0 ? 1 : request.Page;
            int pageSize = request.PageSize == 0 ? 100 : request.PageSize;
            int offset = Math.Max(pageSize * (page - 1), 0);

            long total = 0;

            var rows = await _dataSession
                .StoredProcedure("[Log].[SearchLogs]")
                .Parameter("@Date", request.Date)
                .Parameter("@Level", request.Level)
                .Parameter("@Search", request.Search)
                .Parameter("@Offset", offset)
                .Parameter("@Size", pageSize)
                .ParameterOut("@Total", (Action<long>)(v => total = v))
                .QueryAsync(r =>
                {
                    return new LogEventModel
                    {
                        TimeStamp = r.GetDateTime("TimeStamp"),
                        Level = r.GetString("Level"),
                        Message = r.GetString("Message"),
                        Exception = r.GetString("Exception"),
                        Properties = GetJson(r, "LogEvent")
                    };
                });

            return new EntityPagedResult<LogEventModel>
            {
                Total = total,
                Data = rows.ToList()
            };

        }

        private JsonElement GetJson(System.Data.IDataReader reader, string name)
        {
            var json = reader.GetString(name);
            if (json.IsNullOrWhiteSpace())
                return default;

            try
            {
                JsonDocument jsonDocument = JsonDocument.Parse(json);
                jsonDocument.RootElement.TryGetProperty("Properties", out JsonElement jsonElement);

                return jsonElement;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error parsing JSON: {message}", ex.Message);
                return default;
            }
        }
    }
}
