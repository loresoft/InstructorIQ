using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.Instructor" />
    /// </summary>
    public class InstructorMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Instructor>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.Instructor" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Instructor> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Instructor", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.GivenName)
                .HasColumnName("GivenName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.MiddleName)
                .HasColumnName("MiddleName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.FamilyName)
                .HasColumnName("FamilyName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.DisplayName)
                .IsRequired()
                .HasColumnName("DisplayName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.JobTitle)
                .HasColumnName("JobTitle")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.EmailAddress)
                .HasColumnName("EmailAddress")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.MobilePhone)
                .HasColumnName("MobilePhone")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.BusinessPhone)
                .HasColumnName("BusinessPhone")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

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
                .WithMany(t => t.Instructors)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_Instructor_Tenant_TenantId");

            #endregion

            builder.Property(t => t.PeriodStart)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(t => t.PeriodEnd)
                .ValueGeneratedOnAddOrUpdate();
        }

    }
}
