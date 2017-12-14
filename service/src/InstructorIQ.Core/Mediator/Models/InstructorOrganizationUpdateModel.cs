using System;
using System.Collections.Generic;
using System.Text;
using InstructorIQ.Core.Data.Definitions;

namespace InstructorIQ.Core.Mediator.Models
{
    public class InstructorOrganizationUpdateModel : EntityUpdateModel, IHaveOrganization
    {
        #region Generated Properties
        public Guid InstructorId { get; set; }
        public Guid OrganizationId { get; set; }

        #endregion
    }
}