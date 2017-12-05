using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class TopicReadModel : EntityReadModel
    #region "Custom Interfaces"
        , InstructorIQ.Core.Data.Definitions.IHaveOrganization
    #endregion
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Objectives { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid? LeadInstructorId { get; set; }
        public short CalendarYear { get; set; }

        #region "Custom Properties"
        // The contents of this region will also be preserved during generation.
        public string OrganizationName { get; set; }

        public string LeadInstructorName { get; set; }
        #endregion
    }
}