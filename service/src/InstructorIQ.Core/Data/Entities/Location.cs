using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'Location'.
    /// </summary>
    public class Location : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated, IHaveTenant<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        public Location()
        {
            #region Generated Constructor
            Sessions = new HashSet<Session>();
            #endregion
        }

        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value representing column 'Id'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Id'.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Name'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Name'.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Description'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Description'.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'AddressLine1'.
        /// </summary>
        /// <value>
        /// The property value representing column 'AddressLine1'.
        /// </value>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'AddressLine2'.
        /// </summary>
        /// <value>
        /// The property value representing column 'AddressLine2'.
        /// </value>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'AddressLine3'.
        /// </summary>
        /// <value>
        /// The property value representing column 'AddressLine3'.
        /// </value>
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'City'.
        /// </summary>
        /// <value>
        /// The property value representing column 'City'.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'StateProvince'.
        /// </summary>
        /// <value>
        /// The property value representing column 'StateProvince'.
        /// </value>
        public string StateProvince { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'PostalCode'.
        /// </summary>
        /// <value>
        /// The property value representing column 'PostalCode'.
        /// </value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Latitude'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Latitude'.
        /// </value>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Longitude'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Longitude'.
        /// </value>
        public decimal? Longitude { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Created'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Created'.
        /// </value>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'CreatedBy'.
        /// </summary>
        /// <value>
        /// The property value representing column 'CreatedBy'.
        /// </value>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Updated'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Updated'.
        /// </value>
        public DateTimeOffset Updated { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'UpdatedBy'.
        /// </summary>
        /// <value>
        /// The property value representing column 'UpdatedBy'.
        /// </value>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'RowVersion'.
        /// </summary>
        /// <value>
        /// The property value representing column 'RowVersion'.
        /// </value>
        public Byte[] RowVersion { get; set; }

        #endregion

        #region Generated Relationships
        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Session" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Session" />.
        /// </value>
        public virtual ICollection<Session> Sessions { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="Tenant" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Tenant" />.
        /// </value>
        /// <seealso cref="TenantId" />
        public virtual Tenant Tenant { get; set; }

        #endregion

    }
}
