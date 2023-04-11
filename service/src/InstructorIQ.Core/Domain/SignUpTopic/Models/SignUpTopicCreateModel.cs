using System;
using System.Collections.Generic;

using MediatR.CommandQuery.Models;

namespace InstructorIQ.Core.Domain.Models;

/// <summary>
/// View Model class
/// </summary>
public partial class SignUpTopicCreateModel
    : EntityCreateModel<Guid>
{
    #region Generated Properties
    /// <summary>
    /// Gets or sets the property value for 'SignUpId'.
    /// </summary>
    /// <value>
    /// The property value for 'SignUpId'.
    /// </value>
    public Guid SignUpId { get; set; }

    /// <summary>
    /// Gets or sets the property value for 'TopicId'.
    /// </summary>
    /// <value>
    /// The property value for 'TopicId'.
    /// </value>
    public Guid TopicId { get; set; }

    #endregion

}
