using System;

using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models;

/// <summary>
/// View Model class
/// </summary>
public class SessionUpdateModel
    : EntityUpdateModel, IHaveTenant<Guid>
{
    #region Generated Properties
    /// <summary>
    /// Gets or sets the property value for 'Note'.
    /// </summary>
    /// <value>
    /// The property value for 'Note'.
    /// </value>
    public string Note { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'StartDate'.
    /// </summary>
    /// <value>
    /// The property value for 'StartDate'.
    /// </value>
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'StartTime'.
    /// </summary>
    /// <value>
    /// The property value for 'StartTime'.
    /// </value>
    public TimeOnly? StartTime { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'EndDate'.
    /// </summary>
    /// <value>
    /// The property value for 'EndDate'.
    /// </value>
    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'EndTime'.
    /// </summary>
    /// <value>
    /// The property value for 'EndTime'.
    /// </value>
    public TimeOnly? EndTime { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'TenantId'.
    /// </summary>
    /// <value>
    /// The property value for 'TenantId'.
    /// </value>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'TopicId'.
    /// </summary>
    /// <value>
    /// The property value for 'TopicId'.
    /// </value>
    public Guid TopicId { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'LocationId'.
    /// </summary>
    /// <value>
    /// The property value for 'LocationId'.
    /// </value>
    public Guid? LocationId { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'GroupId'.
    /// </summary>
    /// <value>
    /// The property value for 'GroupId'.
    /// </value>
    public Guid? GroupId { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'LeadInstructorId'.
    /// </summary>
    /// <value>
    /// The property value for 'LeadInstructorId'.
    /// </value>
    public Guid? LeadInstructorId { get; set; }

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
