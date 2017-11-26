using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class SessionMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Session>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Session> builder)
        {
            // table
            builder.ToTable("Session", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(256);
            builder.Property(t => t.Note)
                .HasColumnName("Note");
            builder.Property(t => t.StartTime)
                .HasColumnName("StartTime");
            builder.Property(t => t.EndTime)
                .HasColumnName("EndTime");
            builder.Property(t => t.OrganizationId)
                .IsRequired()
                .HasColumnName("OrganizationId");
            builder.Property(t => t.TopicId)
                .IsRequired()
                .HasColumnName("TopicId");
            builder.Property(t => t.LocationId)
                .HasColumnName("LocationId");
            builder.Property(t => t.LeadInstructorId)
                .HasColumnName("LeadInstructorId");
            builder.Property(t => t.Created)
                .IsRequired()
                .HasColumnName("Created")
                .HasDefaultValueSql("(sysutcdatetime())");
            builder.Property(t => t.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(100);
            builder.Property(t => t.Updated)
                .IsRequired()
                .HasColumnName("Updated")
                .HasDefaultValueSql("(sysutcdatetime())");
            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasMaxLength(100);
            builder.Property(t => t.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .HasColumnName("RowVersion")
                .HasMaxLength(8)
                .ValueGeneratedOnAddOrUpdate();

            // Relationships
            builder.HasOne(t => t.LeadInstructor)
                .WithMany(t => t.LeadSessions)
                .HasForeignKey(d => d.LeadInstructorId)
                .HasConstraintName("FK_Session_Instructor_LeadInstructorId");
            builder.HasOne(t => t.Location)
                .WithMany(t => t.Sessions)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Session_Location_LocationId");
            builder.HasOne(t => t.Organization)
                .WithMany(t => t.Sessions)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_Session_Organization_OrganizationId");
            builder.HasOne(t => t.Topic)
                .WithMany(t => t.Sessions)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK_Session_Topic_TopicId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Session> builder);

    }
}
