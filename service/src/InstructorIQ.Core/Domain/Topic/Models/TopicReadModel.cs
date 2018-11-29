using System;
using EntityFrameworkCore.CommandQuery.Definitions;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public class TopicReadModel
        : EntityReadModel<Guid>, IHaveTenant<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'Title'.
        /// </summary>
        /// <value>
        /// The property value for 'Title'.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Description'.
        /// </summary>
        /// <value>
        /// The property value for 'Description'.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Objectives'.
        /// </summary>
        /// <value>
        /// The property value for 'Objectives'.
        /// </value>
        public string Objectives { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value for 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'LeadInstructorId'.
        /// </summary>
        /// <value>
        /// The property value for 'LeadInstructorId'.
        /// </value>
        public Guid? LeadInstructorId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'CalendarYear'.
        /// </summary>
        /// <value>
        /// The property value for 'CalendarYear'.
        /// </value>
        public short CalendarYear { get; set; }

        #endregion

        public string TenantName { get; set; }
    }
}