using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor" />
    /// </summary>
    public partial class TopicInstructorMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.TopicInstructor>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.TopicInstructor> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("TopicInstructor", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.TopicId)
                .IsRequired()
                .HasColumnName("TopicId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.InstructorId)
                .IsRequired()
                .HasColumnName("InstructorId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.InstructorRoleId)
                .HasColumnName("InstructorRoleId")
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
            builder.HasOne(t => t.InstructorRole)
                .WithMany(t => t.TopicInstructors)
                .HasForeignKey(d => d.InstructorRoleId)
                .HasConstraintName("FK_TopicInstructor_InstructorRole_InstructorRoleId");

            builder.HasOne(t => t.Topic)
                .WithMany(t => t.TopicInstructors)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK_TopicInstructor_Topic_TopicId");

            #endregion

            builder.HasOne(t => t.Instructor)
                .WithMany(t => t.TopicInstructors)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK_SessionInstructor_Instructor_InstructorId");

        }

        #region Generated Constants
        public struct Table
        {
            /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor" /></summary>
            public const string Schema = "IQ";
            /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor" /></summary>
            public const string Name = "TopicInstructor";
        }

        public struct Columns
        {
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor.Id" /></summary>
            public const string Id = "Id";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor.TopicId" /></summary>
            public const string TopicId = "TopicId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor.InstructorId" /></summary>
            public const string InstructorId = "InstructorId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor.InstructorRoleId" /></summary>
            public const string InstructorRoleId = "InstructorRoleId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor.Created" /></summary>
            public const string Created = "Created";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor.CreatedBy" /></summary>
            public const string CreatedBy = "CreatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor.Updated" /></summary>
            public const string Updated = "Updated";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor.UpdatedBy" /></summary>
            public const string UpdatedBy = "UpdatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor.RowVersion" /></summary>
            public const string RowVersion = "RowVersion";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor.PeriodStart" /></summary>
            public const string PeriodStart = "PeriodStart";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor.PeriodEnd" /></summary>
            public const string PeriodEnd = "PeriodEnd";
        }
        #endregion
    }
}
