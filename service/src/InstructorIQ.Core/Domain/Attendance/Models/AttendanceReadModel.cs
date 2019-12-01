using System;
using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public class AttendanceReadModel
        : EntityReadModel<Guid>, IHaveTenant<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'SessionId'.
        /// </summary>
        /// <value>
        /// The property value for 'SessionId'.
        /// </value>
        public Guid SessionId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Attended'.
        /// </summary>
        /// <value>
        /// The property value for 'Attended'.
        /// </value>
        public DateTimeOffset Attended { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'AttendedBy'.
        /// </summary>
        /// <value>
        /// The property value for 'AttendedBy'.
        /// </value>
        public string AttendedBy { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Signature'.
        /// </summary>
        /// <value>
        /// The property value for 'Signature'.
        /// </value>
        public string Signature { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'SignatureType'.
        /// </summary>
        /// <value>
        /// The property value for 'SignatureType'.
        /// </value>
        public string SignatureType { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value for 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        #endregion
    }
}
