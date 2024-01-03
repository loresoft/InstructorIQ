using System;
using System.Collections.Generic;

using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities;

/// <summary>
/// Entity class representing data for table 'TopicInstructor'.
/// </summary>
public partial class TopicInstructor : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TopicInstructor"/> class.
    /// </summary>
    public TopicInstructor()
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
    /// Gets or sets the property value representing column 'TopicId'.
    /// </summary>
    /// <value>
    /// The property value representing column 'TopicId'.
    /// </value>
    public Guid TopicId { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'InstructorId'.
    /// </summary>
    /// <value>
    /// The property value representing column 'InstructorId'.
    /// </value>
    public Guid InstructorId { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'InstructorRoleId'.
    /// </summary>
    /// <value>
    /// The property value representing column 'InstructorRoleId'.
    /// </value>
    public Guid? InstructorRoleId { get; set; }

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
    public long RowVersion { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'PeriodStart'.
    /// </summary>
    /// <value>
    /// The property value representing column 'PeriodStart'.
    /// </value>
    public DateTime PeriodStart { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'PeriodEnd'.
    /// </summary>
    /// <value>
    /// The property value representing column 'PeriodEnd'.
    /// </value>
    public DateTime PeriodEnd { get; set; }

    #endregion

    #region Generated Relationships
    /// <summary>
    /// Gets or sets the navigation property for entity <see cref="InstructorRole" />.
    /// </summary>
    /// <value>
    /// The navigation property for entity <see cref="InstructorRole" />.
    /// </value>
    /// <seealso cref="InstructorRoleId" />
    public virtual InstructorRole InstructorRole { get; set; }

    /// <summary>
    /// Gets or sets the navigation property for entity <see cref="Topic" />.
    /// </summary>
    /// <value>
    /// The navigation property for entity <see cref="Topic" />.
    /// </value>
    /// <seealso cref="TopicId" />
    public virtual Topic Topic { get; set; }

    #endregion

    public virtual User Instructor { get; set; }
}
