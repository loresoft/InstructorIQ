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
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord" /></summary>
        public const string TableSchema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord" /></summary>
        public const string TableName = "HistoryRecord";

        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Id" /></summary>
        public const string ColumnId = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Key" /></summary>
        public const string ColumnKey = "Key";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Entity" /></summary>
        public const string ColumnEntity = "Entity";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.ParentKey" /></summary>
        public const string ColumnParentKey = "ParentKey";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.ParentEntity" /></summary>
        public const string ColumnParentEntity = "ParentEntity";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Changed" /></summary>
        public const string ColumnChanged = "Changed";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.ChangedBy" /></summary>
        public const string ColumnChangedBy = "ChangedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.PropertyName" /></summary>
        public const string ColumnPropertyName = "PropertyName";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.DisplayName" /></summary>
        public const string ColumnDisplayName = "DisplayName";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Path" /></summary>
        public const string ColumnPath = "Path";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Operation" /></summary>
        public const string ColumnOperation = "Operation";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.OriginalValue" /></summary>
        public const string ColumnOriginalValue = "OriginalValue";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.OriginalFormatted" /></summary>
        public const string ColumnOriginalFormatted = "OriginalFormatted";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.OriginalType" /></summary>
        public const string ColumnOriginalType = "OriginalType";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.CurrentValue" /></summary>
        public const string ColumnCurrentValue = "CurrentValue";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.CurrentFormatted" /></summary>
        public const string ColumnCurrentFormatted = "CurrentFormatted";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.CurrentType" /></summary>
        public const string ColumnCurrentType = "CurrentType";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Created" /></summary>
        public const string ColumnCreated = "Created";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.CreatedBy" /></summary>
        public const string ColumnCreatedBy = "CreatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.Updated" /></summary>
        public const string ColumnUpdated = "Updated";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.UpdatedBy" /></summary>
        public const string ColumnUpdatedBy = "UpdatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.HistoryRecord.RowVersion" /></summary>
        public const string ColumnRowVersion = "RowVersion";
        #endregion

    }
}
