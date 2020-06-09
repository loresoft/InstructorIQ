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
using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class DiscussionHistoryQueryHandler : DataContextHandlerBase<InstructorIQContext, DiscussionHistoryQuery, IReadOnlyCollection<AuditRecord<Guid>>>
    {
        private readonly IChangeCollector<Guid, DiscussionReadModel> _changeCollector;

        public DiscussionHistoryQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, IChangeCollector<Guid, DiscussionReadModel> changeCollector) : base(loggerFactory, dataContext, mapper)
        {
            _changeCollector = changeCollector;
        }

        protected override async Task<IReadOnlyCollection<AuditRecord<Guid>>> Process(DiscussionHistoryQuery request, CancellationToken cancellationToken)
        {
            var parameters = new List<object>();

            var sql = new StringBuilder();
            sql.AppendLine("SELECT *");
            sql.AppendLine("FROM [IQ].[Discussion]");
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

            var entities = await DataContext.Discussions
                .FromSqlRaw(sql.ToString(), parameters.ToArray())
                .AsNoTracking()
                .OrderBy(p => p.PeriodEnd)
                .ProjectTo<DiscussionReadModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var historyList = new List<AuditRecord<Guid>>();

            // group changes by id
            foreach (var group in entities.GroupBy(p => p.Id))
            {
                var groupList = group
                    .OrderBy(p => p.PeriodEnd)
                    .ToList();

                var changeList = _changeCollector.CollectChanges(groupList, nameof(Discussion), d => d.DisplayName);
                historyList.AddRange(changeList);
            }

            return historyList.ToList();

        }
    }
}
