using System;
using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class AttendanceSessionModel
        : EntityReadModel<Guid>, IHaveTenant<Guid>
    {
        public Guid SessionId { get; set; }

        public DateTimeOffset Attended { get; set; }

        public string AttendedBy { get; set; }

        public Guid TenantId { get; set; }
    }
}