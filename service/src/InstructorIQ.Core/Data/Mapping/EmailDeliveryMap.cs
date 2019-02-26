using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery" />
    /// </summary>
    public class EmailDeliveryMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.EmailDelivery>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.EmailDelivery> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("EmailDelivery", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.IsProcessing)
                .IsRequired()
                .HasColumnName("IsProcessing")
                .HasColumnType("bit");

            builder.Property(t => t.IsDelivered)
                .IsRequired()
                .HasColumnName("IsDelivered")
                .HasColumnType("bit");

            builder.Property(t => t.Delivered)
                .HasColumnName("Delivered")
                .HasColumnType("datetimeoffset");

            builder.Property(t => t.Attempts)
                .IsRequired()
                .HasColumnName("Attempts")
                .HasColumnType("int");

            builder.Property(t => t.LastAttempt)
                .HasColumnName("LastAttempt")
                .HasColumnType("datetimeoffset");

            builder.Property(t => t.NextAttempt)
                .HasColumnName("NextAttempt")
                .HasColumnType("datetimeoffset");

            builder.Property(t => t.SmtpLog)
                .HasColumnName("SmtpLog")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.Error)
                .HasColumnName("Error")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.From)
                .HasColumnName("From")
                .HasColumnType("nvarchar(265)")
                .HasMaxLength(265);

            builder.Property(t => t.To)
                .HasColumnName("To")
                .HasColumnType("nvarchar(265)")
                .HasMaxLength(265);

            builder.Property(t => t.Subject)
                .HasColumnName("Subject")
                .HasColumnType("nvarchar(265)")
                .HasMaxLength(265);

            builder.Property(t => t.MimeMessage)
                .HasColumnName("MimeMessage")
                .HasColumnType("varbinary(max)");

            builder.Property(t => t.TenantId)
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

            // relationships
            builder.HasOne(t => t.Tenant)
                .WithMany(t => t.EmailDeliveries)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_EmailDelivery_Tenant_TenantId");

            #endregion
        }

    }
}
