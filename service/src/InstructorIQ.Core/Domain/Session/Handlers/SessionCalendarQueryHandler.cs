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
            DateTime startDate;
            DateTime endDate;

            // if month send, then select only one month
            if (message.Month.HasValue)
            {
                startDate = new DateTime(message.Year, message.Month.Value, 1);
                endDate = startDate.AddMonths(1);
            }
            // if no month, select whole year
            else
            {
                startDate = new DateTime(message.Year, 1, 1);
                endDate = startDate.AddYears(1);
            }

            var query = DataContext.Sessions
                .AsNoTracking()
                .Where(q => q.TenantId == message.TenantId)
                .Where(q => q.StartDate >= startDate && q.StartDate < endDate)
                .OrderBy(q => q.StartDate)
                .ThenBy(q => q.StartTime);

            var result = await query
                .ProjectTo<SessionCalendarModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}