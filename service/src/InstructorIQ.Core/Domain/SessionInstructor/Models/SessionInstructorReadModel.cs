using System;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public class SessionInstructorReadModel
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
        /// Gets or sets the property value for 'InstructorId'.
        /// </summary>
        /// <value>
        /// The property value for 'InstructorId'.
        /// </value>
        public Guid InstructorId { get; set; }

        #endregion

    }
}
