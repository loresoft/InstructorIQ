using System;
using System.Collections.Generic;
using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'Notification'.
    /// </summary>
    public partial class Notification : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        public Notification()
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
        /// Gets or sets the property value representing column 'Type'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Type'.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Message'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Message'.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'UserName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'UserName'.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Read'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Read'.
        /// </value>
        public DateTimeOffset? Read { get; set; }

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
