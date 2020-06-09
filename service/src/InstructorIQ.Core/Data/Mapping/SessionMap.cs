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

            builder.Property(t => t.Note)
                .HasColumnName("Note")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("date");

            builder.Property(t => t.StartTime)
                .HasColumnName("StartTime")
                .HasColumnType("time(1)");

            builder.Property(t => t.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("date");

            builder.Property(t => t.EndTime)
                .HasColumnName("EndTime")
                .HasColumnType("time(1)");

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

            builder.Property(t => t.GroupId)
                .HasColumnName("GroupId")
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
            builder.HasOne(t => t.Group)
                .WithMany(t => t.Sessions)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Session_Group_GroupId");

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

            builder.Property(t => t.PeriodStart)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(t => t.PeriodEnd)
                .ValueGeneratedOnAddOrUpdate();
        }

        #region Generated Constants
        public struct Table
        {
            /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Session" /></summary>
            public const string Schema = "IQ";
            /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Session" /></summary>
            public const string Name = "Session";
        }

        public struct Columns
        {
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.Id" /></summary>
            public const string Id = "Id";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.Note" /></summary>
            public const string Note = "Note";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.StartDate" /></summary>
            public const string StartDate = "StartDate";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.StartTime" /></summary>
            public const string StartTime = "StartTime";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.EndDate" /></summary>
            public const string EndDate = "EndDate";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.EndTime" /></summary>
            public const string EndTime = "EndTime";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.TenantId" /></summary>
            public const string TenantId = "TenantId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.TopicId" /></summary>
            public const string TopicId = "TopicId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.LocationId" /></summary>
            public const string LocationId = "LocationId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.GroupId" /></summary>
            public const string GroupId = "GroupId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.LeadInstructorId" /></summary>
            public const string LeadInstructorId = "LeadInstructorId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.Created" /></summary>
            public const string Created = "Created";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.CreatedBy" /></summary>
            public const string CreatedBy = "CreatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.Updated" /></summary>
            public const string Updated = "Updated";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.UpdatedBy" /></summary>
            public const string UpdatedBy = "UpdatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.RowVersion" /></summary>
            public const string RowVersion = "RowVersion";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.PeriodStart" /></summary>
            public const string PeriodStart = "PeriodStart";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Session.PeriodEnd" /></summary>
            public const string PeriodEnd = "PeriodEnd";
        }
        #endregion

    }
}
