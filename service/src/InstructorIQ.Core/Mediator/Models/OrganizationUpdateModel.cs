using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class OrganizationUpdateModel : EntityUpdateModel
    {
        #region Generated Properties
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}