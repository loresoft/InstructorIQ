using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'SessionGroup'.
    /// </summary>
    public class SessionGroup : IHaveIdentifier<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionGroup"/> class.
        /// </summary>
        public SessionGroup()
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
        /// Gets or sets the property value representing column 'SessionId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'SessionId'.
        /// </value>
        public Guid SessionId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'GroupId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'GroupId'.
        /// </value>
        public Guid GroupId { get; set; }

        #endregion

        #region Generated Relationships
        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="Group" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Group" />.
        /// </value>
        /// <seealso cref="GroupId" />
        public virtual Group Group { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="Session" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Session" />.
        /// </value>
        /// <seealso cref="SessionId" />
        public virtual Session Session { get; set; }

        #endregion

    }
}
