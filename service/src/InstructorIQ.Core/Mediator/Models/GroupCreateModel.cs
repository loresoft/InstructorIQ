using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class GroupCreateModel : EntityCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }

        #region "Custom Properties"
        // The contents of this region will also be preserved during generation.

        public string OrganizationName { get; set; }
        #endregion
    }
}