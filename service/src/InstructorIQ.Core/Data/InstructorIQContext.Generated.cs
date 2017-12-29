using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data
{
    public partial class InstructorIQContext
        : DbContext
    {
        public InstructorIQContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<InstructorIQ.Core.Data.Entities.EmailDelivery> EmailDeliveries { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Organization> Organizations { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.EmailTemplate> EmailTemplates { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Group> Groups { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.HistoryRecord> HistoryRecords { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Instructor> Instructors { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.User> Users { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Location> Locations { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.RefreshToken> RefreshTokens { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Role> Roles { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Session> Sessions { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Topic> Topics { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.SessionGroup> SessionGroups { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.SessionInstructor> SessionInstructors { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.UserLogin> UserLogins { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.EmailDeliveryMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.OrganizationMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.EmailTemplateMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.GroupMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.HistoryRecordMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.InstructorMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.LocationMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.RefreshTokenMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.RoleMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.TopicMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionGroupMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionInstructorMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserLoginMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserRoleMap());

            InitializeMapping(modelBuilder);
        }

        partial void InitializeMapping(ModelBuilder modelBuilder);
    }
}