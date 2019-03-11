using System;
using EntityFrameworkCore.CommandQuery.Definitions;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public class SessionCreateModel
        : EntityCreateModel<Guid>, IHaveTenant<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'Note'.
        /// </summary>
        /// <value>
        /// The property value for 'Note'.
        /// </value>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'StartDate'.
        /// </summary>
        /// <value>
        /// The property value for 'StartDate'.
        /// </value>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'StartTime'.
        /// </summary>
        /// <value>
        /// The property value for 'StartTime'.
        /// </value>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'EndDate'.
        /// </summary>
        /// <value>
        /// The property value for 'EndDate'.
        /// </value>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'EndTime'.
        /// </summary>
        /// <value>
        /// The property value for 'EndTime'.
        /// </value>
        public TimeSpan? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value for 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'TopicId'.
        /// </summary>
        /// <value>
        /// The property value for 'TopicId'.
        /// </value>
        public Guid TopicId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'LocationId'.
        /// </summary>
        /// <value>
        /// The property value for 'LocationId'.
        /// </value>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'GroupId'.
        /// </summary>
        /// <value>
        /// The property value for 'GroupId'.
        /// </value>
        public Guid? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'LeadInstructorId'.
        /// </summary>
        /// <value>
        /// The property value for 'LeadInstructorId'.
        /// </value>
        public Guid? LeadInstructorId { get; set; }

        #endregion

    }
}
