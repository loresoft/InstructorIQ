using System;

using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models;

/// <summary>
/// View Model class
/// </summary>
public class TemplateUpdateModel
    : EntityUpdateModel, IHaveTenant<Guid>
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
    /// Gets or sets the property value for 'TemplateBody'.
    /// </summary>
    /// <value>
    /// The property value for 'TemplateBody'.
    /// </value>
    public string TemplateBody { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'TemplateType'.
    /// </summary>
    /// <value>
    /// The property value for 'TemplateType'.
    /// </value>
    public string TemplateType { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'TenantId'.
    /// </summary>
    /// <value>
    /// The property value for 'TenantId'.
    /// </value>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'PeriodStart'.
    /// </summary>
    /// <value>
    /// The property value for 'PeriodStart'.
    /// </value>
    public DateTime PeriodStart { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'PeriodEnd'.
    /// </summary>
    /// <value>
    /// The property value for 'PeriodEnd'.
    /// </value>
    public DateTime PeriodEnd { get; set; }

    #endregion

}
