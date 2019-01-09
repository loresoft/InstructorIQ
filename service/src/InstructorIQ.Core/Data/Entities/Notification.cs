using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Definitions;

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
            NotificationRecipients = new HashSet<NotificationRecipient>();
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
        /// Gets or sets the property value representing column 'CorrelationType'.
        /// </summary>
        /// <value>
        /// The property value representing column 'CorrelationType'.
        /// </value>
        public string CorrelationType { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'CorrelationId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'CorrelationId'.
        /// </value>
        public Guid? CorrelationId { get; set; }

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
        /// Gets or sets the navigation collection for entity <see cref="NotificationRecipient" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="NotificationRecipient" />.
        /// </value>
        public virtual ICollection<NotificationRecipient> NotificationRecipients { get; set; }

        #endregion

    }
}
