using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Jobs;

public class TopicSummaryOneTimeJob : DatabaseOneTimeJobBase
{
    private readonly IHtmlService _htmlService;

    public TopicSummaryOneTimeJob(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IHtmlService htmlService)
        : base(loggerFactory, dataContext)
    {
        _htmlService = htmlService;
    }

    public override Guid Id { get; } = new Guid("051b8ec8-0c05-4b16-bb6e-730659a2e62c");

    public override async Task ProcessAsync(CancellationToken stoppingToken)
    {
        var topics = await DataContext.Topics
            .Where(p => p.Summary == null || p.Summary.Length == 0)
            .Where(p => p.Description != null || p.Description.Length > 1)
            .ToListAsync(stoppingToken);

        // fix topic summary text
        foreach (var topic in topics)
        {
            if (topic.Summary.HasValue())
                continue;

            if (topic.Description.IsNullOrWhiteSpace())
                continue;

            var summary = _htmlService
                .PlainText(topic.Description)
                .RemoveExtended()
                .Truncate(256);

            topic.Summary = summary;

            await DataContext.SaveChangesAsync(stoppingToken);
        }
    }
}
