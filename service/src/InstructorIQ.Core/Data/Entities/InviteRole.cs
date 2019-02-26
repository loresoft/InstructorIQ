using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'InviteRole'.
    /// </summary>
    public partial class InviteRole : IHaveIdentifier<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InviteRole"/> class.
        /// </summary>
        public InviteRole()
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
        /// Gets or sets the property value representing column 'InviteId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'InviteId'.
        /// </value>
        public Guid InviteId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'RoleName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'RoleName'.
        /// </value>
        public string RoleName { get; set; }

        #endregion

        #region Generated Relationships
        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="Invite" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Invite" />.
        /// </value>
        /// <seealso cref="InviteId" />
        public virtual Invite Invite { get; set; }

        #endregion

    }
}
