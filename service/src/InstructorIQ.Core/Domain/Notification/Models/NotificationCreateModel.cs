using System;
using System.Collections.Generic;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public partial class NotificationCreateModel
        : EntityCreateModel<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'Type'.
        /// </summary>
        /// <value>
        /// The property value for 'Type'.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Message'.
        /// </summary>
        /// <value>
        /// The property value for 'Message'.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'UserName'.
        /// </summary>
        /// <value>
        /// The property value for 'UserName'.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Read'.
        /// </summary>
        /// <value>
        /// The property value for 'Read'.
        /// </value>
        public DateTimeOffset? Read { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value for 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        #endregion

    }
}
