using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityChange.Extensions;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class AttendanceSessionQueryHandler
        : DataContextHandlerBase<InstructorIQContext, AttendanceSessionQuery, IReadOnlyCollection<AttendanceSessionModel>>
    {
        public AttendanceSessionQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<IReadOnlyCollection<AttendanceSessionModel>> Process(AttendanceSessionQuery request, CancellationToken cancellationToken)
        {
            var query = DataContext.Attendances
                .AsNoTracking()
                .Where(q => q.TenantId == request.TenantId);

            if (request.TopicId.HasValue)
                query = query.Where(q => q.Session.TopicId == request.TopicId.Value);

            if (request.UserName.HasValue())
                query = query.Where(q => q.AttendeeEmail.Contains(request.UserName));

            if (request.StartDate.HasValue)
                query = query.Where(q => q.Session.StartDate >= request.StartDate && q.Session.StartDate < request.EndDate);

            if (request.SearchText.HasValue())
                query = query.Where(q => q.Session.Topic.Title.Contains(request.SearchText));

            query = query
                .OrderBy(q => q.Session.StartDate)
                .ThenBy(q => q.Session.StartTime)
                .ThenBy(q => q.Session.Topic.Title);

            var result = await query
                .ProjectTo<AttendanceSessionModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
