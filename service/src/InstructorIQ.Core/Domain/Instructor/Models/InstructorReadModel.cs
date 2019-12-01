using System;
using InstructorIQ.Core.Definitions;
using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public class InstructorReadModel
        : EntityReadModel<Guid>, IHaveTenant<Guid>, ITrackHistory
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'GivenName'.
        /// </summary>
        /// <value>
        /// The property value for 'GivenName'.
        /// </value>
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'MiddleName'.
        /// </summary>
        /// <value>
        /// The property value for 'MiddleName'.
        /// </value>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'FamilyName'.
        /// </summary>
        /// <value>
        /// The property value for 'FamilyName'.
        /// </value>
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'DisplayName'.
        /// </summary>
        /// <value>
        /// The property value for 'DisplayName'.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'SortName'.
        /// </summary>
        /// <value>
        /// The property value for 'SortName'.
        /// </value>
        public string SortName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'JobTitle'.
        /// </summary>
        /// <value>
        /// The property value for 'JobTitle'.
        /// </value>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'EmailAddress'.
        /// </summary>
        /// <value>
        /// The property value for 'EmailAddress'.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'MobilePhone'.
        /// </summary>
        /// <value>
        /// The property value for 'MobilePhone'.
        /// </value>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'BusinessPhone'.
        /// </summary>
        /// <value>
        /// The property value for 'BusinessPhone'.
        /// </value>
        public string BusinessPhone { get; set; }

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
