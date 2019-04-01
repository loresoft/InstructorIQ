using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'SessionInstructor'.
    /// </summary>
    public class SessionInstructor : IHaveIdentifier<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionInstructor"/> class.
        /// </summary>
        public SessionInstructor()
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

        #endregion

        #region Generated Relationships
        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="Instructor" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Instructor" />.
        /// </value>
        /// <seealso cref="InstructorId" />
        public virtual Instructor Instructor { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="InstructorRole" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="InstructorRole" />.
        /// </value>
        /// <seealso cref="InstructorRoleId" />
        public virtual InstructorRole InstructorRole { get; set; }

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
