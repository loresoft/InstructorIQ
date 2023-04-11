using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;

using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers;

public class SessionHistoryQueryHandler : DataContextHandlerBase<InstructorIQContext, SessionHistoryQuery, IReadOnlyCollection<AuditRecord<Guid>>>
{
    private readonly IChangeCollector<Guid, SessionReadModel> _changeCollector;

    public SessionHistoryQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, IChangeCollector<Guid, SessionReadModel> changeCollector) : base(loggerFactory, dataContext, mapper)
    {
        _changeCollector = changeCollector;
    }

    protected override async Task<IReadOnlyCollection<AuditRecord<Guid>>> Process(SessionHistoryQuery request, CancellationToken cancellationToken)
    {
        var parameters = new List<object>();

        var sql = new StringBuilder();
        sql.AppendLine("SELECT *");
        sql.AppendLine("FROM [IQ].[Session]");
        sql.AppendLine("FOR SYSTEM_TIME ALL");

        if (request.Id.HasValue)
        {
            sql.AppendLine("WHERE [Id] = {0}");
            parameters.Add(request.Id.Value);
        }
        else if (request.TopicId.HasValue)
        {
            sql.AppendLine("WHERE [TopicId] = {0}");
            parameters.Add(request.TopicId.Value);
        }

        var entities = await DataContext.Sessions
            .FromSqlRaw(sql.ToString(), parameters.ToArray())
            .AsNoTracking()
            .OrderBy(p => p.PeriodEnd)
            .ProjectTo<SessionReadModel>(Mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var historyList = new List<AuditRecord<Guid>>();

        // group changes by id
        foreach (var group in entities.GroupBy(p => p.Id))
        {
            var groupList = group
                .OrderBy(p => p.PeriodEnd)
                .ToList();

            var changeList = _changeCollector.CollectChanges(groupList, nameof(Session), SessionDescription);
            historyList.AddRange(changeList);
        }

        return historyList.ToList();

    }

    private static string SessionDescription(SessionReadModel model)
    {
        var builder = new StringBuilder();
        builder.Append(model.TopicTitle);

        if (model.GroupName.HasValue())
        {
            builder.Append(" - ");
            builder.Append(model.GroupName);
        }

        if (model.StartDate.HasValue)
        {
            builder.Append(" - ");
            builder.Append(model.StartDate.Value.ToString("MMM dd"));
        }
        if (model.StartTime.HasValue)
        {
            builder.Append(" ");
            builder.Append(model.StartTime.Value.ToString(@"hh\:mm"));
        }
        if (model.EndTime.HasValue)
        {
            builder.Append("-");
            builder.Append(model.EndTime.Value.ToString(@"hh\:mm"));
        }

        return builder.ToString();
    }
}
