using System;
using EntityFrameworkCore.CommandQuery.Models;
using InstructorIQ.Core.Definitions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class SessionCreateModel : EntityCreateModel<Guid>, IHaveOrganization
    {
        #region Generated Properties
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid TopicId { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? LeadInstructorId { get; set; }

        #endregion
    }
}