using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using EntityChange;

using FluentCommand.Extensions;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR;
using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers;

public class TopicHistoryQueryHandler : DataContextHandlerBase<InstructorIQContext, TopicHistoryQuery, IReadOnlyCollection<AuditRecord<Guid>>>
{
    private readonly IMediator _mediator;
    private readonly IChangeCollector<Guid, TopicReadModel> _changeCollector;

    public TopicHistoryQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, IMediator mediator, IChangeCollector<Guid, TopicReadModel> changeCollector)
        : base(loggerFactory, dataContext, mapper)
    {
        _mediator = mediator;
        _changeCollector = changeCollector;
    }

    protected override async Task<IReadOnlyCollection<AuditRecord<Guid>>> Process(TopicHistoryQuery request, CancellationToken cancellationToken)
    {
        var historyList = new List<AuditRecord<Guid>>();

        var topicHistoryList = await CollectTopicHistory(request, cancellationToken);
        historyList.AddRange(topicHistoryList);

        var sessionHistoryList = await CollectSessionHistory(request, cancellationToken);
        historyList.AddRange(sessionHistoryList);

        var instructorHistoryList = await CollectSessionInstructorHistory(request, cancellationToken);
        historyList.AddRange(instructorHistoryList);

        var discussionHistoryList = await CollectDiscussionHistory(request, cancellationToken);
        historyList.AddRange(discussionHistoryList);

        return historyList
            .Where(p => p.Operation != AuditOperation.Update || (p.Operation == AuditOperation.Update && p.Changes?.Count > 0))
            .OrderBy(p => p.ActivityDate)
            .ToList();
    }


    private async Task<List<AuditRecord<Guid>>> CollectTopicHistory(TopicHistoryQuery request, CancellationToken cancellationToken)
    {
        var sql = new StringBuilder();
        sql.AppendLine("SELECT *");
        sql.AppendLine("FROM [IQ].[Topic]");
        sql.AppendLine("FOR SYSTEM_TIME ALL");
        sql.AppendLine("WHERE [Id] = {0}");

        var entities = await DataContext.Topics
            .FromSqlRaw(sql.ToString(), request.Id)
            .AsNoTracking()
            .OrderBy(p => p.PeriodEnd)
            .ProjectTo<TopicReadModel>(Mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var historyList = _changeCollector.CollectChanges(entities, nameof(Topic), t => t.Title);

        return historyList.ToList();
    }

    private async Task<IReadOnlyCollection<AuditRecord<Guid>>> CollectSessionHistory(TopicHistoryQuery request, CancellationToken cancellationToken)
    {
        var command = new SessionHistoryQuery(request.Principal) { TopicId = request.Id };
        return await _mediator.Send(command, cancellationToken);
    }

    private async Task<IReadOnlyCollection<AuditRecord<Guid>>> CollectSessionInstructorHistory(TopicHistoryQuery request, CancellationToken cancellationToken)
    {
        var command = new SessionInstructorHistoryQuery(request.Principal) { TopicId = request.Id };
        return await _mediator.Send(command, cancellationToken);
    }

    private async Task<IReadOnlyCollection<AuditRecord<Guid>>> CollectDiscussionHistory(TopicHistoryQuery request, CancellationToken cancellationToken)
    {
        var command = new DiscussionHistoryQuery(request.Principal) { TopicId = request.Id };
        return await _mediator.Send(command, cancellationToken);
    }
}
