using System;
using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public class GroupReadModel
        : EntityReadModel<Guid>, IHaveTenant<Guid>, ITrackHistory
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
        /// Gets or sets the property value for 'Description'.
        /// </summary>
        /// <value>
        /// The property value for 'Description'.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Sequence'.
        /// </summary>
        /// <value>
        /// The property value for 'Sequence'.
        /// </value>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'DisplayOrder'.
        /// </summary>
        /// <value>
        /// The property value for 'DisplayOrder'.
        /// </value>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value for 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'PeriodStart'.
        /// </summary>
        /// <value>
        /// The property value for 'PeriodStart'.
        /// </value>
        public DateTime PeriodStart { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'PeriodEnd'.
        /// </summary>
        /// <value>
        /// The property value for 'PeriodEnd'.
        /// </value>
        public DateTime PeriodEnd { get; set; }

        #endregion

        public string TenantName { get; set; }
    }
}
