using System;

using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models;

public class SessionInstructorModel : EntityReadModel<Guid>, ITrackHistory

{
    public Guid SessionId { get; set; }

    public Guid InstructorId { get; set; }

    public string GivenName { get; set; }

    public string FamilyName { get; set; }

    public string DisplayName { get; set; }

    public string SortName { get; set; }

    public string Email { get; set; }

    public DateTime PeriodStart { get; set; }

    public DateTime PeriodEnd { get; set; }
}
