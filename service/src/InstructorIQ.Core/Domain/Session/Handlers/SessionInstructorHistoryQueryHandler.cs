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

public class SessionInstructorHistoryQueryHandler : DataContextHandlerBase<InstructorIQContext, SessionInstructorHistoryQuery, IReadOnlyCollection<AuditRecord<Guid>>>
{
    private readonly IChangeCollector<Guid, SessionInstructorModel> _changeCollector;

    public SessionInstructorHistoryQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, IChangeCollector<Guid, SessionInstructorModel> changeCollector) : base(loggerFactory, dataContext, mapper)
    {
        _changeCollector = changeCollector;
    }

    protected override async Task<IReadOnlyCollection<AuditRecord<Guid>>> Process(SessionInstructorHistoryQuery request, CancellationToken cancellationToken)
    {
        var parameters = new List<object>();

        var sql = new StringBuilder();
        sql.AppendLine("SELECT S.*");
        sql.AppendLine("FROM [IQ].[SessionInstructor]");
        sql.AppendLine("FOR SYSTEM_TIME ALL AS S");

        if (request.SessionId.HasValue)
        {
            sql.AppendLine("WHERE S.[SessionId] = {0}");
            parameters.Add(request.SessionId.Value);
        }
        else if (request.TopicId.HasValue)
        {
            sql.AppendLine("INNER JOIN [IQ].[Session] AS J ON J.[Id] = S.[SessionId]");
            sql.AppendLine("WHERE J.[TopicId] = {0}");
            parameters.Add(request.TopicId.Value);
        }

        var entities = await DataContext.SessionInstructors
            .FromSqlRaw(sql.ToString(), parameters.ToArray())
            .AsNoTracking()
            .OrderBy(p => p.PeriodEnd)
            .ProjectTo<SessionInstructorModel>(Mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var historyList = new List<AuditRecord<Guid>>();

        // group changes by id
        foreach (var group in entities.GroupBy(p => p.Id))
        {
            var groupList = group
                .OrderBy(p => p.PeriodEnd)
                .ToList();

            var changeList = _changeCollector.CollectChanges(groupList, nameof(SessionInstructor), s => s.DisplayName);
            historyList.AddRange(changeList);
        }

        return historyList.ToList();

    }
}
