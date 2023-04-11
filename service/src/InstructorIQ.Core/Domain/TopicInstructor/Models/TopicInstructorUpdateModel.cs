using System;
using System.Collections.Generic;

using MediatR.CommandQuery.Models;

namespace InstructorIQ.Core.Domain.Models;

/// <summary>
/// View Model class
/// </summary>
public partial class TopicInstructorUpdateModel
    : EntityUpdateModel
{
    #region Generated Properties
    /// <summary>
    /// Gets or sets the property value for 'TopicId'.
    /// </summary>
    /// <value>
    /// The property value for 'TopicId'.
    /// </value>
    public Guid TopicId { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'InstructorId'.
    /// </summary>
    /// <value>
    /// The property value for 'InstructorId'.
    /// </value>
    public Guid InstructorId { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'InstructorRoleId'.
    /// </summary>
    /// <value>
    /// The property value for 'InstructorRoleId'.
    /// </value>
    public Guid? InstructorRoleId { get; set; }

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
