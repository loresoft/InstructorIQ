using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityChange;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Definitions;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Services
{
    public interface IHistoryService
    {
        Task Process(CancellationToken cancellationToken);
    }

    public class HistoryService : IHistoryService
    {
        private readonly InstructorIQContext _dataContext;
        private readonly EntityComparer _entityComparer;
        private readonly IMapper _mapper;

        public HistoryService(InstructorIQContext dataContext, EntityComparer entityComparer, IMapper mapper)
        {
            _dataContext = dataContext;
            _entityComparer = entityComparer;
            _mapper = mapper;
        }

        public async Task Process(CancellationToken cancellationToken)
        {
            // query last run date

            // query source for [PeriodStart] >= @startDate

            // if row, query history for [PeriodEnd] >= @startDate

            // collect history

            // write history

            // write new last run date

            //switch (model)
            //{
            //    case typeof
            //}
            //var locationHistoryList = await _dataContext.Locations
            //    .AsTracking()
            //    .FromSql("SELECT * FROM [IQ].[Location] FOR SYSTEM_TIME ALL WHERE [Id] = '{0}' ORDER BY [PeriodEnd]", locationId)
            //    .ToListAsync(cancellationToken);

            //if (locationHistoryList.Count < 2)
            //    return;

            //var historyRecords = CollectHistory(locationHistoryList);

            //await SaveHistory(historyRecords, cancellationToken);

            await ProcessTopic(cancellationToken);
        }

        private async Task ProcessTopic(CancellationToken cancellationToken)
        {
            var locationHistoryList = await _dataContext.Topics
                .AsNoTracking()
                .FromSql("SELECT * FROM [IQ].[Topic] FOR SYSTEM_TIME ALL")
                .ProjectTo<TopicReadModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        }

        private async Task SaveHistory(List<HistoryRecord> historyRecords, CancellationToken cancellationToken)
        {
            _dataContext.HistoryRecords.AddRange(historyRecords);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        private List<HistoryRecord> CollectHistory<TEntity>(List<TEntity> entities)
            where TEntity : IHaveIdentifier<Guid>, ITrackUpdated
        {
            var historyRecords = new List<HistoryRecord>();

            if (entities.Count < 2)
                return historyRecords;

            var entityName = nameof(TEntity);
            var previous = entities[0];

            for (int i = 1; i < entities.Count; i++)
            {
                var current = entities[i];

                var changes = _entityComparer
                    .Compare(previous, current)
                    .ToList();

                var records = changes
                    .Select(c => new HistoryRecord
                    {
                        Changed = current.Updated,
                        ChangedBy = current.UpdatedBy,
                        Entity = entityName,
                        Key = current.Id,
                        Operation = c.Operation.ToString(),
                        PropertyName = c.PropertyName,
                        DisplayName = c.DisplayName,
                        Path = c.Path,
                        OriginalFormatted = c.OriginalFormatted,
                        CurrentFormatted = c.CurrentFormatted
                    })
                    .ToList();

                historyRecords.AddRange(records);

                previous = current;
            }

            return historyRecords;
        }
    }
}
