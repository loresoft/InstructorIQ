using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Utility;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers
{
    public class EventRangeQueryHandler : DataContextHandlerBase<InstructorIQContext, EventRangeQuery, IReadOnlyCollection<EventReadModel>>
    {
        private readonly IUrlHelper _urlHelper;
        private readonly ITenant<TenantReadModel> _tenant;

        public EventRangeQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, IUrlHelper urlHelper, ITenant<TenantReadModel> tenant)
            : base(loggerFactory, dataContext, mapper)
        {
            _urlHelper = urlHelper;
            _tenant = tenant;
        }

        protected override async Task<IReadOnlyCollection<EventReadModel>> Process(EventRangeQuery request, CancellationToken cancellationToken)
        {
            var query = DataContext.Sessions
                .AsNoTracking()
                .Where(q => q.TenantId == request.TenantId)
                .Where(q => q.StartDate >= request.Start && q.StartDate < request.End)
                .OrderBy(q => q.StartDate)
                .ThenBy(q => q.StartTime);

            var sessions = await query
                .ProjectTo<SessionReadModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            // convert to event
            var events = new List<EventReadModel>();

            foreach (var session in sessions)
            {
                var eventModel = new EventReadModel();
                eventModel.Id = session.Id.ToString();
                eventModel.AllDay = false;
                eventModel.Editable = false;

                eventModel.Title = $"{session.TopicTitle} - {session.GroupName}";

                if (session.IsRequired)
                {
                    if (eventModel.ClassNames == null)
                        eventModel.ClassNames = new List<string>();

                    eventModel.ClassNames.Add("event-required");
                }

                var startDate = DateTimeFactory.Create(session.StartDate, session.StartTime, session.TenantTimeZone);
                eventModel.Start = startDate?.ToUniversalTime();

                var endDate = DateTimeFactory.Create(session.EndDate, session.EndTime, session.TenantTimeZone);
                eventModel.End = endDate?.ToUniversalTime();

                var tenant = _tenant?.Value?.Slug ?? string.Empty;

                var url = _urlHelper.Page(
                    "/topic/session/view",
                    values: new
                    {
                        tenant,
                        topicId = session.TopicId,
                        id = session.Id
                    }
                );

                eventModel.Url = url;

                events.Add(eventModel);
            }
            return events;
        }
    }
}
