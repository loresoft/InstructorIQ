using System;
using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'Attendance'.
    /// </summary>
    public class Attendance : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated, IHaveTenant<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Attendance"/> class.
        /// </summary>
        public Attendance()
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
        /// Gets or sets the property value representing column 'SessionId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'SessionId'.
        /// </value>
        public Guid SessionId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Attended'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Attended'.
        /// </value>
        public DateTimeOffset Attended { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'AttendedBy'.
        /// </summary>
        /// <value>
        /// The property value representing column 'AttendedBy'.
        /// </value>
        public string AttendedBy { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Signature'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Signature'.
        /// </value>
        public string Signature { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'SignatureType'.
        /// </summary>
        /// <value>
        /// The property value representing column 'SignatureType'.
        /// </value>
        public string SignatureType { get; set; }

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
        /// Gets or sets the navigation property for entity <see cref="Session" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Session" />.
        /// </value>
        /// <seealso cref="SessionId" />
        public virtual Session Session { get; set; }

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
