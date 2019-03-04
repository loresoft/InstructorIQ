using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityFrameworkCore.CommandQuery.Extensions;
using EntityFrameworkCore.CommandQuery.Handlers;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class TopicSessionQueryHandler : DataContextHandlerBase<InstructorIQContext, TopicSessionQuery, IReadOnlyCollection<SessionReadModel>>
    {
        private readonly UserClaimManager _userClaimManager;

        public TopicSessionQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserClaimManager userClaimManager)
            : base(loggerFactory, dataContext, mapper)
        {
            _userClaimManager = userClaimManager;
        }

        protected override async Task<IReadOnlyCollection<SessionReadModel>> Process(TopicSessionQuery message, CancellationToken cancellationToken)
        {
            var query = DataContext.Sessions
                .AsNoTracking()
                .Where(s => s.TopicId == message.TopicId);

            var tenantString = _userClaimManager.GetTenantId(message.Principal);
            if (Guid.TryParse(tenantString, out var tenantId))
                query = query.Where(q => q.TenantId == tenantId);

            if (message.Sort != null)
                query = query.Sort(new[] { message.Sort });

            var result = await query
                .ProjectTo<SessionReadModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
