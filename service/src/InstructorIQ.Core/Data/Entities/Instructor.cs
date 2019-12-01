using System;
using System.Collections.Generic;
using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'Instructor'.
    /// </summary>
    public class Instructor : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated, IHaveTenant<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Instructor"/> class.
        /// </summary>
        public Instructor()
        {
            #region Generated Constructor
            LeadSessions = new HashSet<Session>();
            LeadTopics = new HashSet<Topic>();
            SessionInstructors = new HashSet<SessionInstructor>();
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
        /// Gets or sets the property value representing column 'GivenName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'GivenName'.
        /// </value>
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'MiddleName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'MiddleName'.
        /// </value>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'FamilyName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'FamilyName'.
        /// </value>
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'DisplayName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'DisplayName'.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'SortName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'SortName'.
        /// </value>
        public string SortName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'JobTitle'.
        /// </summary>
        /// <value>
        /// The property value representing column 'JobTitle'.
        /// </value>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'EmailAddress'.
        /// </summary>
        /// <value>
        /// The property value representing column 'EmailAddress'.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'MobilePhone'.
        /// </summary>
        /// <value>
        /// The property value representing column 'MobilePhone'.
        /// </value>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'BusinessPhone'.
        /// </summary>
        /// <value>
        /// The property value representing column 'BusinessPhone'.
        /// </value>
        public string BusinessPhone { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Created'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Created'.
        /// </value>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'CreatedBy'.
        /// </summary>
        /// <value>
        /// The property value representing column 'CreatedBy'.
        /// </value>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Updated'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Updated'.
        /// </value>
        public DateTimeOffset Updated { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'UpdatedBy'.
        /// </summary>
        /// <value>
        /// The property value representing column 'UpdatedBy'.
        /// </value>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'RowVersion'.
        /// </summary>
        /// <value>
        /// The property value representing column 'RowVersion'.
        /// </value>
        public Byte[] RowVersion { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'PeriodStart'.
        /// </summary>
        /// <value>
        /// The property value representing column 'PeriodStart'.
        /// </value>
        public DateTime PeriodStart { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'PeriodEnd'.
        /// </summary>
        /// <value>
        /// The property value representing column 'PeriodEnd'.
        /// </value>
        public DateTime PeriodEnd { get; set; }

        #endregion

        #region Generated Relationships
        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Session" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Session" />.
        /// </value>
        public virtual ICollection<Session> LeadSessions { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Topic" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Topic" />.
        /// </value>
        public virtual ICollection<Topic> LeadTopics { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="SessionInstructor" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="SessionInstructor" />.
        /// </value>
        public virtual ICollection<SessionInstructor> SessionInstructors { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="Tenant" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Tenant" />.
        /// </value>
        /// <seealso cref="TenantId" />
        public virtual Tenant Tenant { get; set; }

        #endregion

    }
}
