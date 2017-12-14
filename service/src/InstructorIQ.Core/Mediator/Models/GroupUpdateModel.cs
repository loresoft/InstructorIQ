using System;
using System.Collections.Generic;
using System.Text;
using InstructorIQ.Core.Data.Definitions;

namespace InstructorIQ.Core.Mediator.Models
{
    public class GroupUpdateModel : EntityUpdateModel, IHaveOrganization
    {
        #region Generated Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }

        #endregion
    }
}