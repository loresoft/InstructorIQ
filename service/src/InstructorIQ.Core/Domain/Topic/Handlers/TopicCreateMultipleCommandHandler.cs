using System.Threading;
using System.Threading.Tasks;
using FluentCommand;
using FluentCommand.Merge;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Handlers;
using MediatR.CommandQuery.Models;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class TopicCreateMultipleCommandHandler
        : RequestHandlerBase<TopicCreateMultipleCommand, CommandCompleteModel>
    {
        private readonly IDataSession _dataSession;

        public TopicCreateMultipleCommandHandler(ILoggerFactory loggerFactory, IDataSession dataSession) : base(loggerFactory)
        {
            _dataSession = dataSession;
        }

        protected override async Task<CommandCompleteModel> Process(TopicCreateMultipleCommand request, CancellationToken cancellationToken)
        {
            if (request.Topics.Count == 0)
            {
                Logger.LogWarning("No topics to process");
                return new CommandCompleteModel();
            }

            int rows = await _dataSession
                .MergeData("[IQ].[Topic]")
                .IncludeInsert()
                .IncludeUpdate(false)
                .Mode(DataMergeMode.SqlStatement)
                .Map<TopicCreateModel>(m =>
                {
                    m.Column(p => p.Id).Key();
                    m.Column(p => p.TenantId);
                    m.Column(p => p.Title);
                    m.Column(p => p.Description);
                    m.Column(p => p.CalendarYear);
                    m.Column(p => p.TargetMonth);
                    m.Column(p => p.Created);
                    m.Column(p => p.CreatedBy);
                    m.Column(p => p.Updated);
                    m.Column(p => p.UpdatedBy);
                })
                .ExecuteAsync(request.Topics, cancellationToken);

            Logger.LogInformation("Created {rows} topics", rows);

            return new CommandCompleteModel();

        }
    }
}
