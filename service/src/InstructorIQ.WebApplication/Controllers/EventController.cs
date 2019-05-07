using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Exceptionless.Models;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace InstructorIQ.WebApplication.Controllers
{
    [Route("api/event")]
    public class EventController : MediatorControllerBase
    {
        public EventController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{tenantId}")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid tenantId, DateTimeOffset start, DateTimeOffset end)
        {
            var command = new EventRangeQuery(User, tenantId, start, end);
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }


        [HttpGet("ical/{tenant}")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, string tenant)
        {
            var query = new TenantSlugQuery(User, tenant);
            var tenantModel = await Mediator.Send(query);
            var tenantId = tenantModel.Id;
            var start = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(60));
            var end = start.AddYears(1);

            var command = new EventRangeQuery(User, tenantId, start, end);
            var events = await Mediator.Send(command, cancellationToken);


            var calendar = new Ical.Net.Calendar();
            calendar.Method = "PUBLISH";

            foreach (var e in events)
            {
                var calendarEvent = new CalendarEvent();
                calendarEvent.Class = "PUBLIC";
                calendarEvent.Uid = e.Id;
                calendarEvent.Summary = e.Title;
                calendarEvent.Description = e.Description;
                calendarEvent.Location = e.Location;
                calendarEvent.Categories.Add("Training");

                if (e.Start.HasValue)
                    calendarEvent.Start = new CalDateTime(e.Start.Value.DateTime);

                if (e.End.HasValue)
                    calendarEvent.End = new CalDateTime(e.End.Value.DateTime);

                calendarEvent.LastModified = new CalDateTime(e.Modified.DateTime);
                
                calendar.Events.Add(calendarEvent);
            }

            var serializationContext = new SerializationContext();
            var calendarSerializer = new CalendarSerializer(serializationContext);
            var calendarText = calendarSerializer.SerializeToString(calendar);

            var contentType = "text/calendar; charset=utf-8";

            var contentDisposition = new System.Net.Mime.ContentDisposition();
            contentDisposition.FileName = "training.ics";
            contentDisposition.Inline = true;

            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
            Response.Headers.Add("X-Content-Type-Options", "nosniff");

            return Content(calendarText, contentType, Encoding.UTF8);
        }
    }
}