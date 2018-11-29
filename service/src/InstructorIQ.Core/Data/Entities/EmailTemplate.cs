using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'EmailTemplate'.
    /// </summary>
    public partial class EmailTemplate : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailTemplate"/> class.
        /// </summary>
        public EmailTemplate()
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
        /// Gets or sets the property value representing column 'Key'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Key'.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'FromAddress'.
        /// </summary>
        /// <value>
        /// The property value representing column 'FromAddress'.
        /// </value>
        public string FromAddress { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'FromName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'FromName'.
        /// </value>
        public string FromName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'ReplyToAddress'.
        /// </summary>
        /// <value>
        /// The property value representing column 'ReplyToAddress'.
        /// </value>
        public string ReplyToAddress { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'ReplyToName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'ReplyToName'.
        /// </value>
        public string ReplyToName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Subject'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Subject'.
        /// </value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'TextBody'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TextBody'.
        /// </value>
        public string TextBody { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'HtmlBody'.
        /// </summary>
        /// <value>
        /// The property value representing column 'HtmlBody'.
        /// </value>
        public string HtmlBody { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TenantId'.
        /// </value>
        public Guid? OrganizationId { get; set; }

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
        /// <seealso cref="OrganizationId" />
        public virtual Tenant Tenant { get; set; }

        #endregion

    }
}
