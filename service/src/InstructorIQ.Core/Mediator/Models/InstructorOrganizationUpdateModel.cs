using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class InstructorOrganizationUpdateModel : EntityUpdateModel
    {
        public Guid InstructorId { get; set; }
        public Guid OrganizationId { get; set; }

        #region "Custom Properties"
        // The contents of this region will also be preserved during generation.
        #endregion
    }
}