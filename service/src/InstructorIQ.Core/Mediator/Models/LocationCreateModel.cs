using System;
using System.Collections.Generic;
using System.Text;
using InstructorIQ.Core.Data.Definitions;

namespace InstructorIQ.Core.Mediator.Models
{
    public class LocationCreateModel : EntityCreateModel, IHaveOrganization
    {
        #region Generated Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public Guid OrganizationId { get; set; }

        #endregion
    }
}