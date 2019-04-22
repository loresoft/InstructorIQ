using System;
using System.Collections.Generic;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'Discussion'.
    /// </summary>
    public partial class Discussion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Discussion"/> class.
        /// </summary>
        public Discussion()
        {
            #region Generated Constructor
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
        /// Gets or sets the property value representing column 'TopicId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TopicId'.
        /// </value>
        public Guid TopicId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Message'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Message'.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'MessageDate'.
        /// </summary>
        /// <value>
        /// The property value representing column 'MessageDate'.
        /// </value>
        public DateTimeOffset MessageDate { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'EmailAddress'.
        /// </summary>
        /// <value>
        /// The property value representing column 'EmailAddress'.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'DisplayName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'DisplayName'.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'UserAgent'.
        /// </summary>
        /// <value>
        /// The property value representing column 'UserAgent'.
        /// </value>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Browser'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Browser'.
        /// </value>
        public string Browser { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'OperatingSystem'.
        /// </summary>
        /// <value>
        /// The property value representing column 'OperatingSystem'.
        /// </value>
        public string OperatingSystem { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'DeviceFamily'.
        /// </summary>
        /// <value>
        /// The property value representing column 'DeviceFamily'.
        /// </value>
        public string DeviceFamily { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'DeviceBrand'.
        /// </summary>
        /// <value>
        /// The property value representing column 'DeviceBrand'.
        /// </value>
        public string DeviceBrand { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'DeviceModel'.
        /// </summary>
        /// <value>
        /// The property value representing column 'DeviceModel'.
        /// </value>
        public string DeviceModel { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'IpAddress'.
        /// </summary>
        /// <value>
        /// The property value representing column 'IpAddress'.
        /// </value>
        public string IpAddress { get; set; }

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
        /// Gets or sets the navigation property for entity <see cref="Tenant" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Tenant" />.
        /// </value>
        /// <seealso cref="TenantId" />
        public virtual Tenant Tenant { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="Topic" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Topic" />.
        /// </value>
        /// <seealso cref="TopicId" />
        public virtual Topic Topic { get; set; }

        #endregion

    }
}
