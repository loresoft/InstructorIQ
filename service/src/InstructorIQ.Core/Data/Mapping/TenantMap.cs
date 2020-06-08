using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.Tenant" />
    /// </summary>
    public partial class TenantMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Tenant>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.Tenant" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Tenant> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Tenant", "IQ");

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

            builder.Property(t => t.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.City)
                .HasColumnName("City")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.StateProvince)
                .HasColumnName("StateProvince")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.TimeZone)
                .IsRequired()
                .HasColumnName("TimeZone")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150)
                .HasDefaultValueSql("('Central Standard Time')");

            builder.Property(t => t.DomainName)
                .HasColumnName("DomainName")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted")
                .HasColumnType("bit");

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
            #endregion

            builder.Property(t => t.PeriodStart)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(t => t.PeriodEnd)
                .ValueGeneratedOnAddOrUpdate();
        }

        #region Generated Constants
        public struct Table
        {
            /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Tenant" /></summary>
            public const string Schema = "IQ";
            /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Tenant" /></summary>
            public const string Name = "Tenant";
        }

        public struct Columns
        {
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.Id" /></summary>
            public const string Id = "Id";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.Name" /></summary>
            public const string Name = "Name";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.Slug" /></summary>
            public const string Slug = "Slug";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.Description" /></summary>
            public const string Description = "Description";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.City" /></summary>
            public const string City = "City";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.StateProvince" /></summary>
            public const string StateProvince = "StateProvince";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.TimeZone" /></summary>
            public const string TimeZone = "TimeZone";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.DomainName" /></summary>
            public const string DomainName = "DomainName";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.IsDeleted" /></summary>
            public const string IsDeleted = "IsDeleted";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.Created" /></summary>
            public const string Created = "Created";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.CreatedBy" /></summary>
            public const string CreatedBy = "CreatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.Updated" /></summary>
            public const string Updated = "Updated";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.UpdatedBy" /></summary>
            public const string UpdatedBy = "UpdatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.RowVersion" /></summary>
            public const string RowVersion = "RowVersion";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.PeriodStart" /></summary>
            public const string PeriodStart = "PeriodStart";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Tenant.PeriodEnd" /></summary>
            public const string PeriodEnd = "PeriodEnd";
        }
        #endregion

    }
}
