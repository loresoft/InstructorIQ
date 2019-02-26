using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public partial class InviteRoleReadModel
        : EntityReadModel<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'InviteId'.
        /// </summary>
        /// <value>
        /// The property value for 'InviteId'.
        /// </value>
        public Guid InviteId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'RoleName'.
        /// </summary>
        /// <value>
        /// The property value for 'RoleName'.
        /// </value>
        public string RoleName { get; set; }

        #endregion

    }
}
