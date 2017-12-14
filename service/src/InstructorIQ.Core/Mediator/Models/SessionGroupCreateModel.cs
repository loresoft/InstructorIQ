using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class SessionGroupCreateModel : EntityCreateModel
    {
        #region Generated Properties
        public Guid SessionId { get; set; }
        public Guid GroupId { get; set; }

        #endregion
    }
}