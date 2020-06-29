using System;
using System.Collections.Generic;
using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'Session'.
    /// </summary>
    public class Session : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated, IHaveTenant<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Session"/> class.
        /// </summary>
        public Session()
        {
            #region Generated Constructor
            Attendances = new HashSet<Attendance>();
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
        /// Gets or sets the property value representing column 'Note'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Note'.
        /// </value>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'StartDate'.
        /// </summary>
        /// <value>
        /// The property value representing column 'StartDate'.
        /// </value>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'StartTime'.
        /// </summary>
        /// <value>
        /// The property value representing column 'StartTime'.
        /// </value>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'EndDate'.
        /// </summary>
        /// <value>
        /// The property value representing column 'EndDate'.
        /// </value>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'EndTime'.
        /// </summary>
        /// <value>
        /// The property value representing column 'EndTime'.
        /// </value>
        public TimeSpan? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'TopicId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TopicId'.
        /// </value>
        public Guid TopicId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'LocationId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'LocationId'.
        /// </value>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'GroupId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'GroupId'.
        /// </value>
        public Guid? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'LeadInstructorId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'LeadInstructorId'.
        /// </value>
        public Guid? LeadInstructorId { get; set; }

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
        /// Gets or sets the navigation collection for entity <see cref="Attendance" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Attendance" />.
        /// </value>
        public virtual ICollection<Attendance> Attendances { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="Group" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Group" />.
        /// </value>
        /// <seealso cref="GroupId" />
        public virtual Group Group { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="Location" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Location" />.
        /// </value>
        /// <seealso cref="LocationId" />
        public virtual Location Location { get; set; }

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

        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="Topic" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Topic" />.
        /// </value>
        /// <seealso cref="TopicId" />
        public virtual Topic Topic { get; set; }

        #endregion

        public virtual User LeadInstructor { get; set; }
    }
}
