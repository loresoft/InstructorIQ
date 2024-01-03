using System;
using System.Collections.Generic;

using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities;

/// <summary>
/// Entity class representing data for table 'InstructorRole'.
/// </summary>
public class InstructorRole : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated, IHaveTenant<Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InstructorRole"/> class.
    /// </summary>
    public InstructorRole()
    {
        #region Generated Constructor
        SessionInstructors = new HashSet<SessionInstructor>();
        TopicInstructors = new HashSet<TopicInstructor>();
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
    /// Gets or sets the property value representing column 'Name'.
    /// </summary>
    /// <value>
    /// The property value representing column 'Name'.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'Description'.
    /// </summary>
    /// <value>
    /// The property value representing column 'Description'.
    /// </value>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'TenantId'.
    /// </summary>
    /// <value>
    /// The property value representing column 'TenantId'.
    /// </value>
    public Guid TenantId { get; set; }

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

    #endregion

    #region Generated Relationships
    /// <summary>
    /// Gets or sets the navigation collection for entity <see cref="SessionInstructor" />.
    /// </summary>
    /// <value>
    /// The navigation collection for entity <see cref="SessionInstructor" />.
    /// </value>
    public virtual ICollection<SessionInstructor> SessionInstructors { get; set; }

    /// <summary>
    /// Gets or sets the navigation property for entity <see cref="Tenant" />.
    /// </summary>
    /// <value>
    /// The navigation property for entity <see cref="Tenant" />.
    /// </value>
    /// <seealso cref="TenantId" />
    public virtual Tenant Tenant { get; set; }

    /// <summary>
    /// Gets or sets the navigation collection for entity <see cref="TopicInstructor" />.
    /// </summary>
    /// <value>
    /// The navigation collection for entity <see cref="TopicInstructor" />.
    /// </value>
    public virtual ICollection<TopicInstructor> TopicInstructors { get; set; }

    #endregion

}
