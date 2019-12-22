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
                .HasMaxLength(8)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(t => t.PeriodStart)
                .IsRequired()
                .HasColumnName("PeriodStart")
                .HasColumnType("datetime2")
                .HasDefaultValueSql("(sysutcdatetime())");

            builder.Property(t => t.PeriodEnd)
                .IsRequired()
                .HasColumnName("PeriodEnd")
                .HasColumnType("datetime2")
                .HasDefaultValueSql("('9999-12-31 23:59:59.9999999')");

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

            builder.Property(t => t.PeriodStart)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(t => t.PeriodEnd)
                .ValueGeneratedOnAddOrUpdate();
        }

        #region Generated Constants
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Topic" /></summary>
        public const string TableSchema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Topic" /></summary>
        public const string TableName = "Topic";

        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Id" /></summary>
        public const string ColumnId = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Title" /></summary>
        public const string ColumnTitle = "Title";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Description" /></summary>
        public const string ColumnDescription = "Description";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.TenantId" /></summary>
        public const string ColumnTenantId = "TenantId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.LeadInstructorId" /></summary>
        public const string ColumnLeadInstructorId = "LeadInstructorId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.LessonPlan" /></summary>
        public const string ColumnLessonPlan = "LessonPlan";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Notes" /></summary>
        public const string ColumnNotes = "Notes";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.IsRequired" /></summary>
        public const string ColumnIsRequired = "IsRequired";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.IsPublished" /></summary>
        public const string ColumnIsPublished = "IsPublished";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.CalendarYear" /></summary>
        public const string ColumnCalendarYear = "CalendarYear";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.TargetMonth" /></summary>
        public const string ColumnTargetMonth = "TargetMonth";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Created" /></summary>
        public const string ColumnCreated = "Created";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.CreatedBy" /></summary>
        public const string ColumnCreatedBy = "CreatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.Updated" /></summary>
        public const string ColumnUpdated = "Updated";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.UpdatedBy" /></summary>
        public const string ColumnUpdatedBy = "UpdatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.RowVersion" /></summary>
        public const string ColumnRowVersion = "RowVersion";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.PeriodStart" /></summary>
        public const string ColumnPeriodStart = "PeriodStart";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Topic.PeriodEnd" /></summary>
        public const string ColumnPeriodEnd = "PeriodEnd";
        #endregion

    }
}
