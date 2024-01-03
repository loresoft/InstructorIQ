using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping;

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
            .HasColumnType("bit")
            .HasDefaultValue(false);

        builder.Property(t => t.IsDelivered)
            .IsRequired()
            .HasColumnName("IsDelivered")
            .HasColumnType("bit")
            .HasDefaultValue(false);

        builder.Property(t => t.Delivered)
            .HasColumnName("Delivered")
            .HasColumnType("datetimeoffset");

        builder.Property(t => t.Attempts)
            .IsRequired()
            .HasColumnName("Attempts")
            .HasColumnType("int")
            .HasDefaultValue(0);

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
            .HasConversion<byte[]>()
            .IsRowVersion()
            .IsConcurrencyToken()
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

    #region Generated Constants
    public readonly struct Table
    {
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery" /></summary>
        public const string Schema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery" /></summary>
        public const string Name = "EmailDelivery";
    }

    public readonly struct Columns
    {
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.Id" /></summary>
        public const string Id = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.IsProcessing" /></summary>
        public const string IsProcessing = "IsProcessing";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.IsDelivered" /></summary>
        public const string IsDelivered = "IsDelivered";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.Delivered" /></summary>
        public const string Delivered = "Delivered";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.Attempts" /></summary>
        public const string Attempts = "Attempts";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.LastAttempt" /></summary>
        public const string LastAttempt = "LastAttempt";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.NextAttempt" /></summary>
        public const string NextAttempt = "NextAttempt";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.SmtpLog" /></summary>
        public const string SmtpLog = "SmtpLog";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.Error" /></summary>
        public const string Error = "Error";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.From" /></summary>
        public const string From = "From";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.To" /></summary>
        public const string To = "To";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.Subject" /></summary>
        public const string Subject = "Subject";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.MimeMessage" /></summary>
        public const string MimeMessage = "MimeMessage";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.TenantId" /></summary>
        public const string TenantId = "TenantId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.Created" /></summary>
        public const string Created = "Created";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.CreatedBy" /></summary>
        public const string CreatedBy = "CreatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.Updated" /></summary>
        public const string Updated = "Updated";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.UpdatedBy" /></summary>
        public const string UpdatedBy = "UpdatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery.RowVersion" /></summary>
        public const string RowVersion = "RowVersion";
    }
    #endregion

}
