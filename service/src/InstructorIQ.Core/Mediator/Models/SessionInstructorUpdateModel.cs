using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class SessionInstructorUpdateModel : EntityUpdateModel
    {
        #region Generated Properties
        public Guid SessionId { get; set; }
        public Guid InstructorId { get; set; }

        #endregion
    }
}