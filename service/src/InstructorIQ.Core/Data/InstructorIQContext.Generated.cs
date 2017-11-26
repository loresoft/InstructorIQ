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

        public DbSet<InstructorIQ.Core.Data.Entities.Group> Groups { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Organization> Organizations { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Instructor> Instructors { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.User> Users { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.InstructorOrganization> InstructorOrganizations { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Location> Locations { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Role> Roles { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.RoleClaim> RoleClaims { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Session> Sessions { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Topic> Topics { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.SessionGroup> SessionGroups { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.SessionInstructor> SessionInstructors { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.UserClaim> UserClaims { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.UserLogin> UserLogins { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.UserRole> UserRoles { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.UserToken> UserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.GroupMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.OrganizationMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.InstructorMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.InstructorOrganizationMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.LocationMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.RoleMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.RoleClaimMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.TopicMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionGroupMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionInstructorMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserClaimMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserLoginMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserRoleMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.UserTokenMap());

            InitializeMapping(modelBuilder);
        }

        partial void InitializeMapping(ModelBuilder modelBuilder);
    }
}