using System;
using System.Collections.Generic;

using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models;

/// <summary>
/// View Model class
/// </summary>
public partial class InstructorRoleUpdateModel
    : EntityUpdateModel
{
    #region Generated Properties
    /// <summary>
    /// Gets or sets the property value for 'Name'.
    /// </summary>
    /// <value>
    /// The property value for 'Name'.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'Description'.
    /// </summary>
    /// <value>
    /// The property value for 'Description'.
    /// </value>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'TenantId'.
    /// </summary>
    /// <value>
    /// The property value for 'TenantId'.
    /// </value>
    public Guid TenantId { get; set; }

    #endregion

}
