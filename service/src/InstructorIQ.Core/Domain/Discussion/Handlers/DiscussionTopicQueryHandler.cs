using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR.CommandQuery.EntityFrameworkCore.Handlers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers;

public class DiscussionTopicQueryHandler : DataContextHandlerBase<InstructorIQContext, DiscussionTopicQuery, IReadOnlyCollection<DiscussionReadModel>>
{
    public DiscussionTopicQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
        : base(loggerFactory, dataContext, mapper)
    {
    }

    protected override async Task<IReadOnlyCollection<DiscussionReadModel>> Process(DiscussionTopicQuery request, CancellationToken cancellationToken)
    {
        var query = DataContext.Discussions
            .AsNoTracking()
            .Where(s => s.TopicId == request.TopicId);

        var result = await query
            .ProjectTo<DiscussionReadModel>(Mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;
    }
}
