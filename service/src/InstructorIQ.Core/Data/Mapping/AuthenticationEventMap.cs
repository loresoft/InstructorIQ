using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.AuthenticationEvent" />
    /// </summary>
    public partial class AuthenticationEventMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.AuthenticationEvent>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.AuthenticationEvent" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.AuthenticationEvent> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("AuthenticationEvent", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.EmailAddress)
                .IsRequired()
                .HasColumnName("EmailAddress")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.UserName)
                .IsRequired()
                .HasColumnName("UserName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.UserAgent)
                .HasColumnName("UserAgent")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.Browser)
                .HasColumnName("Browser")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.OperatingSystem)
                .HasColumnName("OperatingSystem")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.DeviceFamily)
                .HasColumnName("DeviceFamily")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.DeviceBrand)
                .HasColumnName("DeviceBrand")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.DeviceModel)
                .HasColumnName("DeviceModel")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.IpAddress)
                .HasColumnName("IpAddress")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.IsSuccessful)
                .IsRequired()
                .HasColumnName("IsSuccessful")
                .HasColumnType("bit");

            builder.Property(t => t.FailureMessage)
                .HasColumnName("FailureMessage")
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
                .ValueGeneratedOnAddOrUpdate();

            // relationships
            #endregion
        }

    }
}
