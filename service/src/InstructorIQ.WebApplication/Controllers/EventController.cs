using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;

using InstructorIQ.Core.Domain.Queries;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.WebApplication.Controllers;

[Route("api/event")]
public class EventController : MediatorControllerBase
{
    public EventController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{tenantId}")]
    public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid tenantId, DateTimeOffset start, DateTimeOffset end)
    {
        var startOnly = DateOnly.FromDateTime(start.DateTime);
        var endOnly = DateOnly.FromDateTime(end.DateTime);

        var command = new EventRangeQuery(User, tenantId, startOnly, endOnly);
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }


    [HttpGet("ical/{tenant}", Name = "event-subscribe")]
    public async Task<IActionResult> Get(CancellationToken cancellationToken, string tenant, DateTimeOffset? start, DateTimeOffset? end)
    {
        var query = new TenantSlugQuery(User, tenant);
        var tenantModel = await Mediator.Send(query);
        var tenantId = tenantModel.Id;

        if (start == null)
            start = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(60));

        if (end == null)
            end = start.Value.AddMonths(6);

        var startOnly = DateOnly.FromDateTime(start.Value.DateTime);
        var endOnly = DateOnly.FromDateTime(end.Value.DateTime);

        var command = new EventRangeQuery(User, tenantId, startOnly, endOnly);
        var events = await Mediator.Send(command, cancellationToken);


        var calendar = new Ical.Net.Calendar();
        calendar.Method = "PUBLISH";
        calendar.AddTimeZone(tenantModel.TimeZone);

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
                calendarEvent.Start = new CalDateTime(e.Start.Value.UtcDateTime) { HasTime = true };

            if (e.End.HasValue)
                calendarEvent.End = new CalDateTime(e.End.Value.UtcDateTime) { HasTime = true };

            calendarEvent.LastModified = new CalDateTime(e.Modified.UtcDateTime);

            calendar.Events.Add(calendarEvent);
        }

        var serializationContext = new SerializationContext();
        var calendarSerializer = new CalendarSerializer(serializationContext);
        var calendarText = calendarSerializer.SerializeToString(calendar);

        var contentType = "text/calendar; charset=utf-8";

        var contentDisposition = new System.Net.Mime.ContentDisposition();
        contentDisposition.FileName = "training.ics";
        contentDisposition.Inline = true;

        Response.Headers.Append("Content-Disposition", contentDisposition.ToString());
        Response.Headers.Append("X-Content-Type-Options", "nosniff");

        return Content(calendarText, contentType, Encoding.UTF8);
    }
}
