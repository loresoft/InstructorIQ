using System;
using System.Collections.Generic;

using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities;

/// <summary>
/// Entity class representing data for table 'InstructorSignUpTopic'.
/// </summary>
public partial class SignUpTopic : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SignUpTopic"/> class.
    /// </summary>
    public SignUpTopic()
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
    /// Gets or sets the property value representing column 'SignUpId'.
    /// </summary>
    /// <value>
    /// The property value representing column 'SignUpId'.
    /// </value>
    public Guid SignUpId { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'TopicId'.
    /// </summary>
    /// <value>
    /// The property value representing column 'TopicId'.
    /// </value>
    public Guid TopicId { get; set; }

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
    /// Gets or sets the navigation property for entity <see cref="SignUp" />.
    /// </summary>
    /// <value>
    /// The the navigation property for entity <see cref="SignUp" />.
    /// </value>
    /// <seealso cref="SignUpId" />
    public virtual SignUp SignUp { get; set; }

    /// <summary>
    /// Gets or sets the navigation property for entity <see cref="Topic" />.
    /// </summary>
    /// <value>
    /// The the navigation property for entity <see cref="Topic" />.
    /// </value>
    /// <seealso cref="TopicId" />
    public virtual Topic Topic { get; set; }

    #endregion

}
