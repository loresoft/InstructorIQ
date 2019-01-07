using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.Session" />
    /// </summary>
    public class SessionMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Session>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.Session" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Session> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Session", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.Note)
                .HasColumnName("Note")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.StartTime)
                .HasColumnName("StartTime")
                .HasColumnType("datetimeoffset");

            builder.Property(t => t.EndTime)
                .HasColumnName("EndTime")
                .HasColumnType("datetimeoffset");

            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.TopicId)
                .IsRequired()
                .HasColumnName("TopicId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.LocationId)
                .HasColumnName("LocationId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.LeadInstructorId)
                .HasColumnName("LeadInstructorId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.Created)
                .IsRequired()
                .HasColumnName("Created")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("(sysutcdatetime())");

            builder.Property(t => t.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.Updated)
                .IsRequired()
                .HasColumnName("Updated")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("(sysutcdatetime())");

            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .HasColumnName("RowVersion")
                .HasColumnType("rowversion")
                .ValueGeneratedOnAddOrUpdate();

            // relationships
            builder.HasOne(t => t.LeadInstructor)
                .WithMany(t => t.LeadSessions)
                .HasForeignKey(d => d.LeadInstructorId)
                .HasConstraintName("FK_Session_Instructor_LeadInstructorId");

            builder.HasOne(t => t.Location)
                .WithMany(t => t.Sessions)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Session_Location_LocationId");

            builder.HasOne(t => t.Tenant)
                .WithMany(t => t.Sessions)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_Session_Tenant_TenantId");

            builder.HasOne(t => t.Topic)
                .WithMany(t => t.Sessions)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK_Session_Topic_TopicId");

            #endregion
        }

    }
}
