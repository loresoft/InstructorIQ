using System;
using EntityFrameworkCore.CommandQuery.Definitions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class SessionBulkUpdateModel : IHaveIdentifier<Guid>
    {
        public Guid Id { get; set; }

        public DateTimeOffset? StartTime { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        public Guid? LocationId { get; set; }

        public Guid? GroupId { get; set; }

        public Guid? LeadInstructorId { get; set; }

        public string Note { get; set; }
    }
}