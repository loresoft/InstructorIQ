using System;
using InstructorIQ.Core.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InstructorIQ.Core.Data
{
    /// <summary>
    /// A <see cref="DbContext" /> instance represents a session with the database and can be used to query and save instances of entities.
    /// </summary>
    public class InstructorIQContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstructorIQContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by this <see cref="DbContext" />.</param>
        public InstructorIQContext(DbContextOptions<InstructorIQContext> options)
            : base(options)
        {
        }

        #region Generated Properties
        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Tenant"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Tenant"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Tenant> Tenants { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.TenantUserRole"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.TenantUserRole"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.TenantUserRole> TenantUserRoles { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Instructor"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Instructor"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Instructor> Instructors { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Topic"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Topic"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Topic> Topics { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Invite"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Invite"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Invite> Invites { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.InviteRole"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.InviteRole"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.InviteRole> InviteRoles { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Notification"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Notification"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Notification> Notifications { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.HistoryRecord> HistoryRecords { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Session"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Session"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Session> Sessions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Group"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Group"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Group> Groups { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Location"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Location"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.EmailDelivery> EmailDeliveries { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.EmailTemplate> EmailTemplates { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.RefreshToken"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.RefreshToken"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.RefreshToken> RefreshTokens { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.SessionInstructor"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.SessionInstructor"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.SessionInstructor> SessionInstructors { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.NotificationRecipient"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.NotificationRecipient"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.NotificationRecipient> NotificationRecipients { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.AuthenticationEvent"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.AuthenticationEvent"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.AuthenticationEvent> AuthenticationEvents { get; set; }

        #endregion

        /// <summary>
        /// Configure the model that was discovered from the entity types exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on this context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.TenantMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.TenantUserRoleMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.InstructorMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.TopicMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.InviteMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.InviteRoleMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.NotificationMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.HistoryRecordMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.GroupMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.LocationMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.EmailDeliveryMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.EmailTemplateMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.RefreshTokenMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionInstructorMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.NotificationRecipientMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.AuthenticationEventMap());
            #endregion

            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.RoleMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.RoleClaimMap());

            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserClaimMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserLoginMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserRoleMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserTokenMap());
        }
    }
}
