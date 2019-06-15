using System;
using MediatR.CommandQuery.Models;

namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public partial class DiscussionCreateModel
        : EntityCreateModel<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'TopicId'.
        /// </summary>
        /// <value>
        /// The property value for 'TopicId'.
        /// </value>
        public Guid TopicId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value for 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Message'.
        /// </summary>
        /// <value>
        /// The property value for 'Message'.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'MessageDate'.
        /// </summary>
        /// <value>
        /// The property value for 'MessageDate'.
        /// </value>
        public DateTimeOffset MessageDate { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'EmailAddress'.
        /// </summary>
        /// <value>
        /// The property value for 'EmailAddress'.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'DisplayName'.
        /// </summary>
        /// <value>
        /// The property value for 'DisplayName'.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'UserAgent'.
        /// </summary>
        /// <value>
        /// The property value for 'UserAgent'.
        /// </value>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Browser'.
        /// </summary>
        /// <value>
        /// The property value for 'Browser'.
        /// </value>
        public string Browser { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'OperatingSystem'.
        /// </summary>
        /// <value>
        /// The property value for 'OperatingSystem'.
        /// </value>
        public string OperatingSystem { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'DeviceFamily'.
        /// </summary>
        /// <value>
        /// The property value for 'DeviceFamily'.
        /// </value>
        public string DeviceFamily { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'DeviceBrand'.
        /// </summary>
        /// <value>
        /// The property value for 'DeviceBrand'.
        /// </value>
        public string DeviceBrand { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'DeviceModel'.
        /// </summary>
        /// <value>
        /// The property value for 'DeviceModel'.
        /// </value>
        public string DeviceModel { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'IpAddress'.
        /// </summary>
        /// <value>
        /// The property value for 'IpAddress'.
        /// </value>
        public string IpAddress { get; set; }

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

    }
}
