using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class TopicMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Topic>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Topic> builder)
        {
            // table
            builder.ToTable("Topic", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasMaxLength(256);
            builder.Property(t => t.Description)
                .HasColumnName("Description");
            builder.Property(t => t.Objectives)
                .HasColumnName("Objectives");
            builder.Property(t => t.OrganizationId)
                .IsRequired()
                .HasColumnName("OrganizationId");
            builder.Property(t => t.LeadInstructorId)
                .HasColumnName("LeadInstructorId");
            builder.Property(t => t.CalendarYear)
                .IsRequired()
                .HasColumnName("CalendarYear")
                .HasDefaultValueSql("(datepart(year,getdate()))");
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
                .WithMany(t => t.LeadTopics)
                .HasForeignKey(d => d.LeadInstructorId)
                .HasConstraintName("FK_Topic_Instructor_LeadInstructorId");
            builder.HasOne(t => t.Organization)
                .WithMany(t => t.Topics)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_Topic_Organization_OrganizationId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Topic> builder);

    }
}
