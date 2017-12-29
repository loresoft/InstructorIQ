using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class HistoryRecordMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.HistoryRecord>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.HistoryRecord> builder)
        {
            // table
            builder.ToTable("HistoryRecord", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.Key)
                .IsRequired()
                .HasColumnName("Key");
            builder.Property(t => t.Entity)
                .IsRequired()
                .HasColumnName("Entity")
                .HasMaxLength(100);
            builder.Property(t => t.ParentKey)
                .HasColumnName("ParentKey");
            builder.Property(t => t.ParentEntity)
                .HasColumnName("ParentEntity")
                .HasMaxLength(100);
            builder.Property(t => t.Changed)
                .IsRequired()
                .HasColumnName("Changed")
                .HasDefaultValueSql("(sysutcdatetime())");
            builder.Property(t => t.ChangedBy)
                .HasColumnName("ChangedBy")
                .HasMaxLength(100);
            builder.Property(t => t.PropertyName)
                .HasColumnName("PropertyName")
                .HasMaxLength(256);
            builder.Property(t => t.DisplayName)
                .HasColumnName("DisplayName")
                .HasMaxLength(256);
            builder.Property(t => t.Path)
                .HasColumnName("Path")
                .HasMaxLength(256);
            builder.Property(t => t.Operation)
                .HasColumnName("Operation")
                .HasMaxLength(100);
            builder.Property(t => t.OriginalValue)
                .HasColumnName("OriginalValue");
            builder.Property(t => t.OriginalFormated)
                .HasColumnName("OriginalFormated")
                .HasMaxLength(256);
            builder.Property(t => t.OriginalType)
                .HasColumnName("OriginalType")
                .HasMaxLength(256);
            builder.Property(t => t.CurrentValue)
                .HasColumnName("CurrentValue");
            builder.Property(t => t.CurrentFormated)
                .HasColumnName("CurrentFormated")
                .HasMaxLength(256);
            builder.Property(t => t.CurrentType)
                .HasColumnName("CurrentType")
                .HasMaxLength(256);
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

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.HistoryRecord> builder);

    }
}
