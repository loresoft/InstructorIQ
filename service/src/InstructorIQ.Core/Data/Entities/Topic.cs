using System;
using System.Collections.Generic;
using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'Topic'.
    /// </summary>
    public class Topic : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated, IHaveTenant<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Topic"/> class.
        /// </summary>
        public Topic()
        {
            #region Generated Constructor
            Discussions = new HashSet<Discussion>();
            Sessions = new HashSet<Session>();
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
        /// Gets or sets the property value representing column 'Title'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Title'.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Description'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Description'.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'LeadInstructorId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'LeadInstructorId'.
        /// </value>
        public Guid? LeadInstructorId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'LessonPlan'.
        /// </summary>
        /// <value>
        /// The property value representing column 'LessonPlan'.
        /// </value>
        public string LessonPlan { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Notes'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Notes'.
        /// </value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'IsRequired'.
        /// </summary>
        /// <value>
        /// The property value representing column 'IsRequired'.
        /// </value>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'IsPublished'.
        /// </summary>
        /// <value>
        /// The property value representing column 'IsPublished'.
        /// </value>
        public bool IsPublished { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'CalendarYear'.
        /// </summary>
        /// <value>
        /// The property value representing column 'CalendarYear'.
        /// </value>
        public short CalendarYear { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'TargetMonth'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TargetMonth'.
        /// </value>
        public short? TargetMonth { get; set; }

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

        #endregion

        #region Generated Relationships
        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Discussion" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Discussion" />.
        /// </value>
        public virtual ICollection<Discussion> Discussions { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for entity <see cref="Instructor" />.
        /// </summary>
        /// <value>
        /// The the navigation property for entity <see cref="Instructor" />.
        /// </value>
        /// <seealso cref="LeadInstructorId" />
        public virtual Instructor LeadInstructor { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Session" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Session" />.
        /// </value>
        public virtual ICollection<Session> Sessions { get; set; }

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
