using System;

using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models;

public class AttendanceSessionModel
    : EntityReadModel<Guid>, IHaveTenant<Guid>
{
    public Guid SessionId { get; set; }

    public DateTimeOffset Attended { get; set; }

    public string AttendeeEmail { get; set; }

    public string AttendeeName { get; set; }

    public Guid TenantId { get; set; }


    // session data
    public DateTime? StartDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public DateTime? EndDate { get; set; }

    public TimeSpan? EndTime { get; set; }


    // topic data
    public Guid TopicId { get; set; }

    public string TopicTitle { get; set; }

    // location data
    public Guid? LocationId { get; set; }

    public string LocationName { get; set; }

    // group data
    public Guid? GroupId { get; set; }

    public string GroupName { get; set; }

    public bool IsRequired { get; set; }
}
