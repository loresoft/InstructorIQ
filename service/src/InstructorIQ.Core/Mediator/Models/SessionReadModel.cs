using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class SessionReadModel : EntityReadModel
    #region "Custom Interfaces"
        , InstructorIQ.Core.Data.Definitions.IHaveOrganization
    #endregion
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid TopicId { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? LeadInstructorId { get; set; }

        #region "Custom Properties"
        // The contents of this region will also be preserved during generation.
        public string OrganizationName { get; set; }

        public string TopicName { get; set; }

        public string LocationName { get; set; }

        public string LeadInstructorName { get; set; }
        #endregion
    }
}