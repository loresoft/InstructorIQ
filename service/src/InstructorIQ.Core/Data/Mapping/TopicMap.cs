using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.Topic" />
    /// </summary>
    public class TopicMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Topic>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.Topic" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Topic> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Topic", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.Objectives)
                .HasColumnName("Objectives")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.LeadInstructorId)
                .HasColumnName("LeadInstructorId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.IsRequired)
                .IsRequired()
                .HasColumnName("IsRequired")
                .HasColumnType("bit");

            builder.Property(t => t.IsPublished)
                .IsRequired()
                .HasColumnName("IsPublished")
                .HasColumnType("bit");

            builder.Property(t => t.CalendarYear)
                .IsRequired()
                .HasColumnName("CalendarYear")
                .HasColumnType("smallint")
                .HasDefaultValueSql("(datepart(year,getdate()))");

            builder.Property(t => t.TargetMonth)
                .HasColumnName("TargetMonth")
                .HasColumnType("smallint");

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
                .WithMany(t => t.LeadTopics)
                .HasForeignKey(d => d.LeadInstructorId)
                .HasConstraintName("FK_Topic_Instructor_LeadInstructorId");

            builder.HasOne(t => t.Tenant)
                .WithMany(t => t.Topics)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_Topic_Tenant_TenantId");

            #endregion
        }

    }
}
