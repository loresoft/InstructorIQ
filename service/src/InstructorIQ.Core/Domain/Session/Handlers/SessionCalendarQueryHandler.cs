using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class SessionCalendarQueryHandler : DataContextHandlerBase<InstructorIQContext, SessionCalendarQuery, IReadOnlyCollection<SessionCalendarModel>>
    {
        private readonly UserClaimManager _userClaimManager;

        public SessionCalendarQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserClaimManager userClaimManager)
            : base(loggerFactory, dataContext, mapper)
        {
            _userClaimManager = userClaimManager;
        }

        protected override async Task<IReadOnlyCollection<SessionCalendarModel>> Process(SessionCalendarQuery message, CancellationToken cancellationToken)
        {
            var tenantId = _userClaimManager.GetRequiredTenantId(message.Principal);

            var startDate = new DateTime(message.Year, message.Month, 1);
            var endDate = startDate.AddMonths(1);

            var query = DataContext.Sessions
                .AsNoTracking()
                .Where(q => q.TenantId == tenantId)
                .Where(q => q.StartTime >= startDate && q.StartTime < endDate)
                .OrderBy(q => q.StartTime);

            var result = await query
                .ProjectTo<SessionCalendarModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}