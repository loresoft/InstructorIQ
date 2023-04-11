using System;
using System.Collections.Generic;

namespace InstructorIQ.Core.Data.Entities;

/// <summary>
/// Entity class representing data for table 'ImportJob'.
/// </summary>
public partial class ImportJob
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImportJob"/> class.
    /// </summary>
    public ImportJob()
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
    /// Gets or sets the property value representing column 'TenantId'.
    /// </summary>
    /// <value>
    /// The property value representing column 'TenantId'.
    /// </value>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'MappingJson'.
    /// </summary>
    /// <value>
    /// The property value representing column 'MappingJson'.
    /// </value>
    public string MappingJson { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'StorageFile'.
    /// </summary>
    /// <value>
    /// The property value representing column 'StorageFile'.
    /// </value>
    public string StorageFile { get; set; }

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
