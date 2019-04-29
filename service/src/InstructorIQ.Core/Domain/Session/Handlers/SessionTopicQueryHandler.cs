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
namespace InstructorIQ.Core.Domain.Handlers
{
    public class SessionTopicQueryHandler : DataContextHandlerBase<InstructorIQContext, SessionTopicQuery, IReadOnlyCollection<SessionCalendarModel>>
    {
        public SessionTopicQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<IReadOnlyCollection<SessionCalendarModel>> Process(SessionTopicQuery request, CancellationToken cancellationToken)
        {
            var query = DataContext.Sessions
                .AsNoTracking()
                .Where(s => request.TopicIds.Contains(s.TopicId));

            var result = await query
                .ProjectTo<SessionCalendarModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
