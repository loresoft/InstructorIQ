using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping;

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

        builder.Property(t => t.Summary)
            .HasColumnName("Summary")
            .HasColumnType("nvarchar(256)")
            .HasMaxLength(256);

        builder.Property(t => t.Description)
            .HasColumnName("Description")
            .HasColumnType("nvarchar(max)");

        builder.Property(t => t.TenantId)
            .IsRequired()
            .HasColumnName("TenantId")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.LeadInstructorId)
            .HasColumnName("LeadInstructorId")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.LessonPlan)
            .HasColumnName("LessonPlan")
            .HasColumnType("nvarchar(max)");

        builder.Property(t => t.Notes)
            .HasColumnName("Notes")
            .HasColumnType("nvarchar(max)");

        builder.Property(t => t.IsRequired)
            .IsRequired()
            .HasColumnName("IsRequired")
            .HasColumnType("bit")
            .HasDefaultValue(false);

        builder.Property(t => t.IsPublished)
            .IsRequired()
            .HasColumnName("IsPublished")
            .HasColumnType("bit")
            .HasDefaultValue(false);

        builder.Property(t => t.InstructorSlots)
            .HasColumnName("InstructorSlots")
            .HasColumnType("int");

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
            .HasConversion<byte[]>()
            .IsRowVersion()
            .IsConcurrencyToken()
            .HasColumnName("RowVersion")
            .HasColumnType("rowversion")
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(t => t.PeriodStart)
            .HasColumnName("PeriodStart")
            .HasColumnType("datetime2")
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(t => t.PeriodEnd)
            .HasColumnName("PeriodEnd")
            .HasColumnType("datetime2")
            .ValueGeneratedOnAddOrUpdate();

        // relationships
        builder.HasOne(t => t.Tenant)
            .WithMany(t => t.Topics)
            .HasForeignKey(d => d.TenantId)
            .HasConstraintName("FK_Topic_Tenant_TenantId");

        #endregion

        builder.HasOne(t => t.LeadInstructor)
            .WithMany(t => t.LeadTopics)
            .HasForeignKey(d => d.LeadInstructorId)
            .HasConstraintName("FK_Topic_Instructor_LeadInstructorId");

        builder.Property(t => t.PeriodStart)
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(t => t.PeriodEnd)
            .ValueGeneratedOnAddOrUpdate();
    }

    #region Generated Constants
    public readonly struct Table
    {
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Topic" /></summary>
        public const string Schema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Topic" /></summary>
        public const string Name = "Topic";
    }

    public readonly struct Columns
    {
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Id" /></summary>
        public const string Id = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Title" /></summary>
        public const string Title = "Title";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Summary" /></summary>
        public const string Summary = "Summary";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Description" /></summary>
        public const string Description = "Description";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.TenantId" /></summary>
        public const string TenantId = "TenantId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.LeadInstructorId" /></summary>
        public const string LeadInstructorId = "LeadInstructorId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.LessonPlan" /></summary>
        public const string LessonPlan = "LessonPlan";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Notes" /></summary>
        public const string Notes = "Notes";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.IsRequired" /></summary>
        public const string IsRequired = "IsRequired";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.IsPublished" /></summary>
        public const string IsPublished = "IsPublished";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.InstructorSlots" /></summary>
        public const string InstructorSlots = "InstructorSlots";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.CalendarYear" /></summary>
        public const string CalendarYear = "CalendarYear";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.TargetMonth" /></summary>
        public const string TargetMonth = "TargetMonth";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Created" /></summary>
        public const string Created = "Created";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.CreatedBy" /></summary>
        public const string CreatedBy = "CreatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Updated" /></summary>
        public const string Updated = "Updated";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.UpdatedBy" /></summary>
        public const string UpdatedBy = "UpdatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.RowVersion" /></summary>
        public const string RowVersion = "RowVersion";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.PeriodStart" /></summary>
        public const string PeriodStart = "PeriodStart";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.PeriodEnd" /></summary>
        public const string PeriodEnd = "PeriodEnd";
    }
    #endregion

}
