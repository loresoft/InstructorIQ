using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class SessionGroupUpdateModel : EntityUpdateModel
    {
        public Guid SessionId { get; set; }
        public Guid GroupId { get; set; }

        #region "Custom Properties"
        // The contents of this region will also be preserved during generation.
        #endregion
    }
}