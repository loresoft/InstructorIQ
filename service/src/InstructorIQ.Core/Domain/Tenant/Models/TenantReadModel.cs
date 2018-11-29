using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public partial class TenantReadModel
        : EntityReadModel<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'Name'.
        /// </summary>
        /// <value>
        /// The property value for 'Name'.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Abbreviation'.
        /// </summary>
        /// <value>
        /// The property value for 'Abbreviation'.
        /// </value>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Description'.
        /// </summary>
        /// <value>
        /// The property value for 'Description'.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'IsDeleted'.
        /// </summary>
        /// <value>
        /// The property value for 'IsDeleted'.
        /// </value>
        public bool IsDeleted { get; set; }

        #endregion

    }
}
