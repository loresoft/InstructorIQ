using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class RoleClaimReadModel : EntityReadModel
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public Guid RoleId { get; set; }

        #region "Custom Properties"
        // The contents of this region will also be preserved during generation.
        #endregion
    }
}