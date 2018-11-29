using System;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public class SessionGroupReadModel
        : EntityReadModel<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'SessionId'.
        /// </summary>
        /// <value>
        /// The property value for 'SessionId'.
        /// </value>
        public Guid SessionId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'GroupId'.
        /// </summary>
        /// <value>
        /// The property value for 'GroupId'.
        /// </value>
        public Guid GroupId { get; set; }

        #endregion

    }
}
