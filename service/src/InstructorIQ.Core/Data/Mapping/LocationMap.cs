using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.Location" />
    /// </summary>
    public class LocationMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Location>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.Location" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Location> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Location", "IQ");

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

            builder.Property(t => t.AddressLine1)
                .HasColumnName("AddressLine1")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.AddressLine2)
                .HasColumnName("AddressLine2")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.AddressLine3)
                .HasColumnName("AddressLine3")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.City)
                .HasColumnName("City")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.StateProvince)
                .HasColumnName("StateProvince")
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.PostalCode)
                .HasColumnName("PostalCode")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.ContactName)
                .HasColumnName("ContactName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.ContactEmail)
                .HasColumnName("ContactEmail")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.ContactPhone)
                .HasColumnName("ContactPhone")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Latitude)
                .HasColumnName("Latitude")
                .HasColumnType("decimal(20,10)");

            builder.Property(t => t.Longitude)
                .HasColumnName("Longitude")
                .HasColumnType("decimal(20,10)");

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
            builder.HasOne(t => t.Tenant)
                .WithMany(t => t.Locations)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_Location_Tenant_TenantId");

            #endregion

            builder.Property(t => t.PeriodStart)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(t => t.PeriodEnd)
                .ValueGeneratedOnAddOrUpdate();
        }

        #region Generated Constants
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Location" /></summary>
        public const string TableSchema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Location" /></summary>
        public const string TableName = "Location";

        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.Id" /></summary>
        public const string ColumnId = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.Name" /></summary>
        public const string ColumnName = "Name";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.Description" /></summary>
        public const string ColumnDescription = "Description";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.AddressLine1" /></summary>
        public const string ColumnAddressLine1 = "AddressLine1";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.AddressLine2" /></summary>
        public const string ColumnAddressLine2 = "AddressLine2";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.AddressLine3" /></summary>
        public const string ColumnAddressLine3 = "AddressLine3";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.City" /></summary>
        public const string ColumnCity = "City";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.StateProvince" /></summary>
        public const string ColumnStateProvince = "StateProvince";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.PostalCode" /></summary>
        public const string ColumnPostalCode = "PostalCode";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.ContactName" /></summary>
        public const string ColumnContactName = "ContactName";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.ContactEmail" /></summary>
        public const string ColumnContactEmail = "ContactEmail";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.ContactPhone" /></summary>
        public const string ColumnContactPhone = "ContactPhone";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.Latitude" /></summary>
        public const string ColumnLatitude = "Latitude";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.Longitude" /></summary>
        public const string ColumnLongitude = "Longitude";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.TenantId" /></summary>
        public const string ColumnTenantId = "TenantId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.Created" /></summary>
        public const string ColumnCreated = "Created";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.CreatedBy" /></summary>
        public const string ColumnCreatedBy = "CreatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.Updated" /></summary>
        public const string ColumnUpdated = "Updated";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.UpdatedBy" /></summary>
        public const string ColumnUpdatedBy = "UpdatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.RowVersion" /></summary>
        public const string ColumnRowVersion = "RowVersion";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.PeriodStart" /></summary>
        public const string ColumnPeriodStart = "PeriodStart";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Location.PeriodEnd" /></summary>
        public const string ColumnPeriodEnd = "PeriodEnd";
        #endregion

    }
}
