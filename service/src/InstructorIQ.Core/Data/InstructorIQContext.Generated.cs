using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data
{
    public partial class InstructorIQContext
        : IdentityDbContext<InstructorIQ.Core.Data.Entities.User, InstructorIQ.Core.Data.Entities.Role, Guid>
    {
        public InstructorIQContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<InstructorIQ.Core.Data.Entities.Group> Groups { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Organization> Organizations { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Instructor> Instructors { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.InstructorOrganization> InstructorOrganizations { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Location> Locations { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Session> Sessions { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.Topic> Topics { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.SessionGroup> SessionGroups { get; set; }
        public DbSet<InstructorIQ.Core.Data.Entities.SessionInstructor> SessionInstructors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.GroupMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.OrganizationMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.InstructorMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.InstructorOrganizationMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.LocationMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.TopicMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionGroupMap());
            modelBuilder.ApplyConfiguration(new InstructorIQ.Core.Data.Mapping.SessionInstructorMap());

            InitializeMapping(modelBuilder);
        }

        partial void InitializeMapping(ModelBuilder modelBuilder);
    }
}