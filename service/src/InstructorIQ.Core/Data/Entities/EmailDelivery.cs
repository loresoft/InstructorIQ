using System;
using System.Collections.Generic;

using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities;

/// <summary>
/// Entity class representing data for table 'EmailDelivery'.
/// </summary>
public partial class EmailDelivery : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmailDelivery"/> class.
    /// </summary>
    public EmailDelivery()
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
    /// Gets or sets the property value representing column 'IsProcessing'.
    /// </summary>
    /// <value>
    /// The property value representing column 'IsProcessing'.
    /// </value>
    public bool IsProcessing { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'IsDelivered'.
    /// </summary>
    /// <value>
    /// The property value representing column 'IsDelivered'.
    /// </value>
    public bool IsDelivered { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'Delivered'.
    /// </summary>
    /// <value>
    /// The property value representing column 'Delivered'.
    /// </value>
    public DateTimeOffset? Delivered { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'Attempts'.
    /// </summary>
    /// <value>
    /// The property value representing column 'Attempts'.
    /// </value>
    public int Attempts { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'LastAttempt'.
    /// </summary>
    /// <value>
    /// The property value representing column 'LastAttempt'.
    /// </value>
    public DateTimeOffset? LastAttempt { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'NextAttempt'.
    /// </summary>
    /// <value>
    /// The property value representing column 'NextAttempt'.
    /// </value>
    public DateTimeOffset? NextAttempt { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'SmtpLog'.
    /// </summary>
    /// <value>
    /// The property value representing column 'SmtpLog'.
    /// </value>
    public string SmtpLog { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'Error'.
    /// </summary>
    /// <value>
    /// The property value representing column 'Error'.
    /// </value>
    public string Error { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'From'.
    /// </summary>
    /// <value>
    /// The property value representing column 'From'.
    /// </value>
    public string From { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'To'.
    /// </summary>
    /// <value>
    /// The property value representing column 'To'.
    /// </value>
    public string To { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'Subject'.
    /// </summary>
    /// <value>
    /// The property value representing column 'Subject'.
    /// </value>
    public string Subject { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'MimeMessage'.
    /// </summary>
    /// <value>
    /// The property value representing column 'MimeMessage'.
    /// </value>
    public Byte[] MimeMessage { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'TenantId'.
    /// </summary>
    /// <value>
    /// The property value representing column 'TenantId'.
    /// </value>
    public Guid? TenantId { get; set; }

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
