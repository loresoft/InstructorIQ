using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class TopicReadModel : EntityReadModel, InstructorIQ.Core.Data.Definitions.IHaveOrganization
    {
        #region Generated Properties
        public string Title { get; set; }
        public string Description { get; set; }
        public string Objectives { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid? LeadInstructorId { get; set; }
        public short CalendarYear { get; set; }

        #endregion
        
		public string OrganizationName { get; set; }

        public string LeadInstructorName { get; set; }
    }
}