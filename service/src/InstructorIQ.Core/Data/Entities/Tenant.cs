using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'Tenant'.
    /// </summary>
    public partial class Tenant : IHaveIdentifier<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tenant"/> class.
        /// </summary>
        public Tenant()
        {
            #region Generated Constructor
            Invites = new HashSet<Invite>();
            EmailDeliveries = new HashSet<EmailDelivery>();
            EmailTemplates = new HashSet<EmailTemplate>();
            Groups = new HashSet<Group>();
            Instructors = new HashSet<Instructor>();
            Locations = new HashSet<Location>();
            Sessions = new HashSet<Session>();
            Topics = new HashSet<Topic>();
            LastUsers = new HashSet<User>();
            UserRoles = new HashSet<UserRole>();
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
        /// Gets or sets the property value representing column 'Name'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Name'.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Abbreviation'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Abbreviation'.
        /// </value>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Description'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Description'.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'IsDeleted'.
        /// </summary>
        /// <value>
        /// The property value representing column 'IsDeleted'.
        /// </value>
        public bool IsDeleted { get; set; }

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
        /// Gets or sets the navigation collection for entity <see cref="Invite" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Invite" />.
        /// </value>
        public virtual ICollection<Invite> Invites { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="EmailDelivery" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="EmailDelivery" />.
        /// </value>
        public virtual ICollection<EmailDelivery> EmailDeliveries { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="EmailTemplate" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="EmailTemplate" />.
        /// </value>
        public virtual ICollection<EmailTemplate> EmailTemplates { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Group" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Group" />.
        /// </value>
        public virtual ICollection<Group> Groups { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Instructor" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Instructor" />.
        /// </value>
        public virtual ICollection<Instructor> Instructors { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Location" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Location" />.
        /// </value>
        public virtual ICollection<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Session" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Session" />.
        /// </value>
        public virtual ICollection<Session> Sessions { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Topic" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Topic" />.
        /// </value>
        public virtual ICollection<Topic> Topics { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="User" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="User" />.
        /// </value>
        public virtual ICollection<User> LastUsers { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="UserRole" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="UserRole" />.
        /// </value>
        public virtual ICollection<UserRole> UserRoles { get; set; }

        #endregion

    }
}
