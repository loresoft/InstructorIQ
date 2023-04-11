using System;
using System.Collections.Generic;

namespace InstructorIQ.Core.Data.Entities;

/// <summary>
/// Entity class representing data for table 'LinkToken'.
/// </summary>
public partial class LinkToken
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LinkToken"/> class.
    /// </summary>
    public LinkToken()
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
    /// Gets or sets the property value representing column 'TokenHash'.
    /// </summary>
    /// <value>
    /// The property value representing column 'TokenHash'.
    /// </value>
    public string TokenHash { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'UserName'.
    /// </summary>
    /// <value>
    /// The property value representing column 'UserName'.
    /// </value>
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'Url'.
    /// </summary>
    /// <value>
    /// The property value representing column 'Url'.
    /// </value>
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'TenantId'.
    /// </summary>
    /// <value>
    /// The property value representing column 'TenantId'.
    /// </value>
    public Guid? TenantId { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'Issued'.
    /// </summary>
    /// <value>
    /// The property value representing column 'Issued'.
    /// </value>
    public DateTimeOffset Issued { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'Used'.
    /// </summary>
    /// <value>
    /// The property value representing column 'Used'.
    /// </value>
    public DateTimeOffset? Used { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'Expires'.
    /// </summary>
    /// <value>
    /// The property value representing column 'Expires'.
    /// </value>
    public DateTimeOffset? Expires { get; set; }

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
