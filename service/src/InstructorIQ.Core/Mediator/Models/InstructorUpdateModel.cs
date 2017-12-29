using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class InstructorUpdateModel : EntityUpdateModel
    {
        #region Generated Properties
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public string DisplayName { get; set; }
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public string BusinessPhone { get; set; }
        public Guid? UserId { get; set; }
        public Guid OrganizationId { get; set; }

        #endregion
    }
}