using System;
using EntityFrameworkCore.CommandQuery.Definitions;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public class SessionUpdateModel
        : EntityUpdateModel, IHaveTenant<Guid>
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
        /// Gets or sets the property value for 'StartTime'.
        /// </summary>
        /// <value>
        /// The property value for 'StartTime'.
        /// </value>
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'EndTime'.
        /// </summary>
        /// <value>
        /// The property value for 'EndTime'.
        /// </value>
        public DateTimeOffset? EndTime { get; set; }

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

        /// <summary>
        /// Gets or sets the property value for 'DisplayOrder'.
        /// </summary>
        /// <value>
        /// The property value for 'DisplayOrder'.
        /// </value>
        public int DisplayOrder { get; set; }

        #endregion

    }
}
