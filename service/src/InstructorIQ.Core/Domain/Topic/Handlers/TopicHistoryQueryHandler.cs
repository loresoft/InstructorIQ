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
using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class TopicHistoryQueryHandler : DataContextHandlerBase<InstructorIQContext, TopicHistoryQuery, IReadOnlyCollection<Core.Models.HistoryRecord>>
    {
        private readonly IEntityComparer _entityComparer;

        public TopicHistoryQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, IEntityComparer entityComparer)
            : base(loggerFactory, dataContext, mapper)
        {
            _entityComparer = entityComparer;
        }


        protected override async Task<IReadOnlyCollection<Core.Models.HistoryRecord>> Process(TopicHistoryQuery request, CancellationToken cancellationToken)
        {
            var historyList = new List<Core.Models.HistoryRecord>();

            var topicHistoryList = await CollectTopicHistory(request, cancellationToken);
            historyList.AddRange(topicHistoryList);

            var sessionHistoryList = await CollectSessionHistory(request, cancellationToken);
            historyList.AddRange(sessionHistoryList);

            return historyList
                .OrderBy(p => p.Changed)
                .ToList(); ;
        }


        private async Task<List<Core.Models.HistoryRecord>> CollectTopicHistory(TopicHistoryQuery request, CancellationToken cancellationToken)
        {
            var entities = await DataContext.Topics
                .FromSqlRaw("SELECT * FROM [IQ].[Topic] FOR SYSTEM_TIME ALL WHERE [Id] = {0}", request.Id)
                .AsNoTracking()
                .OrderBy(p => p.PeriodEnd)
                .ProjectTo<TopicReadModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var historyList = CollectHistory(entities, nameof(Topic), t => t.Title);
            return historyList;
        }

        private async Task<List<Core.Models.HistoryRecord>> CollectSessionHistory(TopicHistoryQuery request, CancellationToken cancellationToken)
        {
            var historyList = new List<Core.Models.HistoryRecord>();

            var entities = await DataContext.Sessions
                .FromSqlRaw("SELECT * FROM [IQ].[Session] FOR SYSTEM_TIME ALL WHERE [TopicId] = {0}", request.Id)
                .AsNoTracking()
                .OrderBy(p => p.PeriodEnd)
                .ProjectTo<SessionReadModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            foreach (var group in entities.GroupBy(p => p.Id))
            {
                var groupList = group
                    .OrderBy(p => p.PeriodEnd)
                    .ToList();

                var groupHistory = CollectHistory(groupList, nameof(Session), SessionDescription);
                historyList.AddRange(groupHistory);
            }

            return historyList;
        }


        private List<Core.Models.HistoryRecord> CollectHistory<TEntity>(List<TEntity> entities, string entityName, Func<TEntity, string> descriptionFunction)
            where TEntity : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated, ITrackHistory
        {
            var historyRecords = new List<Core.Models.HistoryRecord>();

            TEntity previous = default;

            for (int i = 0; i < entities.Count; i++)
            {
                var current = entities[i];
                bool isLast = 0 == entities.Count - 1;

                if (isLast && current.PeriodEnd < DateTime.UtcNow)
                {
                    // deleted item
                    var deleteRecord = new Core.Models.HistoryRecord
                    {
                        Changed = current.Updated,
                        ChangedBy = current.UpdatedBy,
                        Entity = entityName,
                        Description = descriptionFunction(current),
                        Key = current.Id,
                        Operation = "Remove"
                    };
                    historyRecords.Add(deleteRecord);
                }
                else if (previous == null)
                {
                    // added item
                    var insertRecord = new Core.Models.HistoryRecord
                    {
                        Changed = current.Created,
                        ChangedBy = current.CreatedBy,
                        Entity = entityName,
                        Description = descriptionFunction(current),
                        Key = current.Id,
                        Operation = "Add"
                    };
                    historyRecords.Add(insertRecord);
                }
                else
                {
                    var changes = _entityComparer
                        .Compare(previous, current)
                        .ToList();

                    var records = changes
                        .Select(c => new Core.Models.HistoryRecord
                        {
                            Changed = current.Updated,
                            ChangedBy = current.UpdatedBy,
                            Entity = entityName,
                            Description = descriptionFunction(current),
                            Key = current.Id,
                            Operation = c.Operation.ToString(),
                            PropertyName = c.PropertyName,
                            DisplayName = c.DisplayName,
                            OriginalFormatted = c.OriginalFormatted,
                            CurrentFormatted = c.CurrentFormatted
                        })
                        .ToList();

                    historyRecords.AddRange(records);
                }

                previous = current;
            }

            return historyRecords;
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
}
