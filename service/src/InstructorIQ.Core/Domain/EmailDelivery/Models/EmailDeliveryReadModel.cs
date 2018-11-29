using System;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public class EmailDeliveryReadModel
        : EntityReadModel<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'IsProcessing'.
        /// </summary>
        /// <value>
        /// The property value for 'IsProcessing'.
        /// </value>
        public bool IsProcessing { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'IsDelivered'.
        /// </summary>
        /// <value>
        /// The property value for 'IsDelivered'.
        /// </value>
        public bool IsDelivered { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Delivered'.
        /// </summary>
        /// <value>
        /// The property value for 'Delivered'.
        /// </value>
        public DateTimeOffset? Delivered { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Attempts'.
        /// </summary>
        /// <value>
        /// The property value for 'Attempts'.
        /// </value>
        public int Attempts { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'LastAttempt'.
        /// </summary>
        /// <value>
        /// The property value for 'LastAttempt'.
        /// </value>
        public DateTimeOffset? LastAttempt { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'NextAttempt'.
        /// </summary>
        /// <value>
        /// The property value for 'NextAttempt'.
        /// </value>
        public DateTimeOffset? NextAttempt { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'SmtpLog'.
        /// </summary>
        /// <value>
        /// The property value for 'SmtpLog'.
        /// </value>
        public string SmtpLog { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Error'.
        /// </summary>
        /// <value>
        /// The property value for 'Error'.
        /// </value>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'From'.
        /// </summary>
        /// <value>
        /// The property value for 'From'.
        /// </value>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'To'.
        /// </summary>
        /// <value>
        /// The property value for 'To'.
        /// </value>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Subject'.
        /// </summary>
        /// <value>
        /// The property value for 'Subject'.
        /// </value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'MimeMessage'.
        /// </summary>
        /// <value>
        /// The property value for 'MimeMessage'.
        /// </value>
        public Byte[] MimeMessage { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'OrganizationId'.
        /// </summary>
        /// <value>
        /// The property value for 'OrganizationId'.
        /// </value>
        public Guid? OrganizationId { get; set; }

        #endregion

    }
}
