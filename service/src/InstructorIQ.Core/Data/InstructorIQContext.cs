using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InstructorIQ.Core.Data
{
    /// <summary>
    /// A <see cref="DbContext" /> instance represents a session with the database and can be used to query and save instances of entities.
    /// </summary>
    public class InstructorIQContext : DbContext
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
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.EmailDelivery> EmailDeliveries { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Tenant"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Tenant"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Tenant> Tenants { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.EmailTemplate> EmailTemplates { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Group"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Group"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Group> Groups { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Instructor"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Instructor"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Instructor> Instructors { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.User"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.User"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.User> Users { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.HistoryRecord> HistoryRecords { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Location"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Location"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.RefreshToken"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.RefreshToken"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.RefreshToken> RefreshTokens { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Session"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Session"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Session> Sessions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Topic"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Topic"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Topic> Topics { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Role"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.Role"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.SessionGroup"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.SessionGroup"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.SessionGroup> SessionGroups { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.SessionInstructor"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.SessionInstructor"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.SessionInstructor> SessionInstructors { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.UserLogin"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.UserLogin"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.UserLogin> UserLogins { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.UserRole"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> that can be used to query and save instances of <see cref="InstructorIQ.Core.Data.Entities.UserRole"/>.
        /// </value>
        public virtual DbSet<InstructorIQ.Core.Data.Entities.UserRole> UserRoles { get; set; }

        #endregion

        /// <summary>
        /// Configure the model that was discovered from the entity types exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on this context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.EmailDeliveryMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.TenantMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.EmailTemplateMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.GroupMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.InstructorMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.HistoryRecordMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.LocationMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.RefreshTokenMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.TopicMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.RoleMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionGroupMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionInstructorMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserLoginMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserRoleMap());
            #endregion
        }
    }
}
