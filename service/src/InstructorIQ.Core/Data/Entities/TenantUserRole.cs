using System;
using System.Collections.Generic;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'TenantUserRole'.
    /// </summary>
    public partial class TenantUserRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantUserRole"/> class.
        /// </summary>
        public TenantUserRole()
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
        /// Gets or sets the property value representing column 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'UserId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'UserId'.
        /// </value>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'RoleId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'RoleId'.
        /// </value>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'UserName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'UserName'.
        /// </value>
        public string UserName { get; set; }

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
        /// Gets or sets the navigation property for entity <see cref="Tenant" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Tenant" />.
        /// </value>
        /// <seealso cref="TenantId" />
        public virtual Tenant Tenant { get; set; }

        #endregion

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
