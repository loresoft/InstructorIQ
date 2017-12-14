using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class SessionUpdateModel : EntityUpdateModel, InstructorIQ.Core.Data.Definitions.IHaveOrganization
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