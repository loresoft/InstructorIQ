using System;
using EntityFrameworkCore.CommandQuery.Definitions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class SessionBulkUpdateModel : IHaveIdentifier<Guid>
    {
        public Guid Id { get; set; }

        public DateTime? StartDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public DateTime? EndDate { get; set; }

        public TimeSpan? EndTime { get; set; }

        public Guid? LocationId { get; set; }

        public Guid? GroupId { get; set; }

        public Guid? LeadInstructorId { get; set; }

        public Guid TopicId { get; set; }

        public string TopicTitle { get; set; }

        public string Note { get; set; }
    }
}