using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord" />
    /// </summary>
    public class HistoryRecordMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.HistoryRecord>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.HistoryRecord> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("HistoryRecord", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.Key)
                .IsRequired()
                .HasColumnName("Key")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.Entity)
                .IsRequired()
                .HasColumnName("Entity")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.ParentKey)
                .HasColumnName("ParentKey")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.ParentEntity)
                .HasColumnName("ParentEntity")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.Changed)
                .IsRequired()
                .HasColumnName("Changed")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("(sysutcdatetime())");

            builder.Property(t => t.ChangedBy)
                .HasColumnName("ChangedBy")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.PropertyName)
                .HasColumnName("PropertyName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.DisplayName)
                .HasColumnName("DisplayName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.Path)
                .HasColumnName("Path")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.Operation)
                .HasColumnName("Operation")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.OriginalValue)
                .HasColumnName("OriginalValue")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.OriginalFormatted)
                .HasColumnName("OriginalFormatted")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.OriginalType)
                .HasColumnName("OriginalType")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.CurrentValue)
                .HasColumnName("CurrentValue")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.CurrentFormatted)
                .HasColumnName("CurrentFormatted")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.CurrentType)
                .HasColumnName("CurrentType")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

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

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord" /></summary>
            public const string Schema = "IQ";
            /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord" /></summary>
            public const string Name = "HistoryRecord";
        }

        public struct Columns
        {
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Id" /></summary>
            public const string Id = "Id";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Key" /></summary>
            public const string Key = "Key";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Entity" /></summary>
            public const string Entity = "Entity";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.ParentKey" /></summary>
            public const string ParentKey = "ParentKey";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.ParentEntity" /></summary>
            public const string ParentEntity = "ParentEntity";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Changed" /></summary>
            public const string Changed = "Changed";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.ChangedBy" /></summary>
            public const string ChangedBy = "ChangedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.PropertyName" /></summary>
            public const string PropertyName = "PropertyName";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.DisplayName" /></summary>
            public const string DisplayName = "DisplayName";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Path" /></summary>
            public const string Path = "Path";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Operation" /></summary>
            public const string Operation = "Operation";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.OriginalValue" /></summary>
            public const string OriginalValue = "OriginalValue";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.OriginalFormatted" /></summary>
            public const string OriginalFormatted = "OriginalFormatted";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.OriginalType" /></summary>
            public const string OriginalType = "OriginalType";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.CurrentValue" /></summary>
            public const string CurrentValue = "CurrentValue";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.CurrentFormatted" /></summary>
            public const string CurrentFormatted = "CurrentFormatted";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.CurrentType" /></summary>
            public const string CurrentType = "CurrentType";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Created" /></summary>
            public const string Created = "Created";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.CreatedBy" /></summary>
            public const string CreatedBy = "CreatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Updated" /></summary>
            public const string Updated = "Updated";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.UpdatedBy" /></summary>
            public const string UpdatedBy = "UpdatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.RowVersion" /></summary>
            public const string RowVersion = "RowVersion";
        }
        #endregion

    }
}
