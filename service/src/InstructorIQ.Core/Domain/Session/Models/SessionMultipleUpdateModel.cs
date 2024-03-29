using System;
using System.Collections.Generic;

using MediatR.CommandQuery.Definitions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models;

public class SessionMultipleUpdateModel : IHaveIdentifier<Guid>
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }

    public DateOnly? StartDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public DateOnly? EndDate { get; set; }

    public TimeOnly? EndTime { get; set; }

    public Guid? LocationId { get; set; }

    public Guid? GroupId { get; set; }

    public Guid? LeadInstructorId { get; set; }

    public Guid TopicId { get; set; }

    public string TopicTitle { get; set; }

    public string Note { get; set; }

    public List<Guid> AdditionalInstructors { get; set; }
}
