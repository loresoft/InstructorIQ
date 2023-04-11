using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models;

public class EventReadModel
{
    public string Id { get; set; }

    public string GroupId { get; set; }

    public bool AllDay { get; set; }

    public DateTimeOffset? Start { get; set; }

    public DateTimeOffset? End { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public string Url { get; set; }

    public bool? Editable { get; set; }

    public bool? Required { get; set; }

    public DateTimeOffset Modified { get; set; }

    public List<string> ClassNames { get; set; }

    public string BackgroundColor { get; set; }

    public string BorderColor { get; set; }

    public string TextColor { get; set; }

}
