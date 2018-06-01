using System;
using EntityFrameworkCore.CommandQuery.Models;
using InstructorIQ.Core.Definitions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class LocationUpdateModel : EntityUpdateModel, IHaveOrganization
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