using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping;

/// <summary>
/// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.Group" />
/// </summary>
public class GroupMap
    : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Group>
{
    /// <summary>
    /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.Group" />
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Group> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("Group", "IQ");

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

        builder.Property(t => t.Description)
            .HasColumnName("Description")
            .HasColumnType("nvarchar(max)");

        builder.Property(t => t.Sequence)
            .IsRequired()
            .HasColumnName("Sequence")
            .HasColumnType("int")
            .HasDefaultValue(0);

        builder.Property(t => t.DisplayOrder)
            .IsRequired()
            .HasColumnName("DisplayOrder")
            .HasColumnType("int")
            .HasDefaultValue(0);

        builder.Property(t => t.TenantId)
            .IsRequired()
            .HasColumnName("TenantId")
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
            .WithMany(t => t.Groups)
            .HasForeignKey(d => d.TenantId)
            .HasConstraintName("FK_Group_Tenant_TenantId");

        #endregion

        builder.Property(t => t.PeriodStart)
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(t => t.PeriodEnd)
            .ValueGeneratedOnAddOrUpdate();
    }

    #region Generated Constants
    public readonly struct Table
    {
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Group" /></summary>
        public const string Schema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Group" /></summary>
        public const string Name = "Group";
    }

    public readonly struct Columns
    {
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.Id" /></summary>
        public const string Id = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.Name" /></summary>
        public const string Name = "Name";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.Description" /></summary>
        public const string Description = "Description";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.Sequence" /></summary>
        public const string Sequence = "Sequence";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.DisplayOrder" /></summary>
        public const string DisplayOrder = "DisplayOrder";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.TenantId" /></summary>
        public const string TenantId = "TenantId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.Created" /></summary>
        public const string Created = "Created";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.CreatedBy" /></summary>
        public const string CreatedBy = "CreatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.Updated" /></summary>
        public const string Updated = "Updated";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.UpdatedBy" /></summary>
        public const string UpdatedBy = "UpdatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.RowVersion" /></summary>
        public const string RowVersion = "RowVersion";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.PeriodStart" /></summary>
        public const string PeriodStart = "PeriodStart";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Group.PeriodEnd" /></summary>
        public const string PeriodEnd = "PeriodEnd";
    }
    #endregion

}
