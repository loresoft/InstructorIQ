using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class UserRoleUpdateModel : EntityUpdateModel
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid RoleId { get; set; }

        #region "Custom Properties"
        // The contents of this region will also be preserved during generation.
        #endregion
    }
}