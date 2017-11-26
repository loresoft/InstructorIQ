using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class UserTokenReadModel : EntityReadModel
    {
        public Guid UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        #region "Custom Properties"
        // The contents of this region will also be preserved during generation.
        #endregion
    }
}