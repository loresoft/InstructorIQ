using System;
using System.Collections.Generic;
using MediatR.CommandQuery.Definitions;

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
            Attendances = new HashSet<Attendance>();
            Discussions = new HashSet<Discussion>();
            EmailDeliveries = new HashSet<EmailDelivery>();
            EmailTemplates = new HashSet<EmailTemplate>();
            Groups = new HashSet<Group>();
            ImportJobs = new HashSet<ImportJob>();
            InstructorRoles = new HashSet<InstructorRole>();
            LinkTokens = new HashSet<LinkToken>();
            Locations = new HashSet<Location>();
            Notifications = new HashSet<Notification>();
            Sessions = new HashSet<Session>();
            SignUps = new HashSet<SignUp>();
            Templates = new HashSet<Template>();
            TenantUserRoles = new HashSet<TenantUserRole>();
            Topics = new HashSet<Topic>();
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
        /// Gets or sets the property value representing column 'Slug'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Slug'.
        /// </value>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Description'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Description'.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'City'.
        /// </summary>
        /// <value>
        /// The property value representing column 'City'.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'StateProvince'.
        /// </summary>
        /// <value>
        /// The property value representing column 'StateProvince'.
        /// </value>
        public string StateProvince { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'TimeZone'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TimeZone'.
        /// </value>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'DomainName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'DomainName'.
        /// </value>
        public string DomainName { get; set; }

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
        /// Gets or sets the navigation collection for entity <see cref="Discussion" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Discussion" />.
        /// </value>
        public virtual ICollection<Discussion> Discussions { get; set; }

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
        /// Gets or sets the navigation collection for entity <see cref="ImportJob" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="ImportJob" />.
        /// </value>
        public virtual ICollection<ImportJob> ImportJobs { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="InstructorRole" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="InstructorRole" />.
        /// </value>
        public virtual ICollection<InstructorRole> InstructorRoles { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="LinkToken" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="LinkToken" />.
        /// </value>
        public virtual ICollection<LinkToken> LinkTokens { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Location" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Location" />.
        /// </value>
        public virtual ICollection<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Notification" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Notification" />.
        /// </value>
        public virtual ICollection<Notification> Notifications { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Session" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Session" />.
        /// </value>
        public virtual ICollection<Session> Sessions { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="SignUp" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="SignUp" />.
        /// </value>
        public virtual ICollection<SignUp> SignUps { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Template" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Template" />.
        /// </value>
        public virtual ICollection<Template> Templates { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="TenantUserRole" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="TenantUserRole" />.
        /// </value>
        public virtual ICollection<TenantUserRole> TenantUserRoles { get; set; }

        /// <summary>
        /// Gets or sets the navigation collection for entity <see cref="Topic" />.
        /// </summary>
        /// <value>
        /// The the navigation collection for entity <see cref="Topic" />.
        /// </value>
        public virtual ICollection<Topic> Topics { get; set; }

        #endregion

    }
}
