using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping;

/// <summary>
/// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate" />
/// </summary>
public class EmailTemplateMap
    : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.EmailTemplate>
{
    /// <summary>
    /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate" />
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.EmailTemplate> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("EmailTemplate", "IQ");

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
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.FromAddress)
            .IsRequired()
            .HasColumnName("FromAddress")
            .HasColumnType("nvarchar(256)")
            .HasMaxLength(256);

        builder.Property(t => t.FromName)
            .IsRequired()
            .HasColumnName("FromName")
            .HasColumnType("nvarchar(256)")
            .HasMaxLength(256);

        builder.Property(t => t.ReplyToAddress)
            .HasColumnName("ReplyToAddress")
            .HasColumnType("nvarchar(256)")
            .HasMaxLength(256);

        builder.Property(t => t.ReplyToName)
            .HasColumnName("ReplyToName")
            .HasColumnType("nvarchar(256)")
            .HasMaxLength(256);

        builder.Property(t => t.Subject)
            .HasColumnName("Subject")
            .HasColumnType("nvarchar(max)");

        builder.Property(t => t.TextBody)
            .HasColumnName("TextBody")
            .HasColumnType("nvarchar(max)");

        builder.Property(t => t.HtmlBody)
            .HasColumnName("HtmlBody")
            .HasColumnType("nvarchar(max)");

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
            .WithMany(t => t.EmailTemplates)
            .HasForeignKey(d => d.TenantId)
            .HasConstraintName("FK_EmailTemplate_Tenant_TenantId");

        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate" /></summary>
        public const string Schema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate" /></summary>
        public const string Name = "EmailTemplate";
    }

    public readonly struct Columns
    {
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.Id" /></summary>
        public const string Id = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.Key" /></summary>
        public const string Key = "Key";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.FromAddress" /></summary>
        public const string FromAddress = "FromAddress";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.FromName" /></summary>
        public const string FromName = "FromName";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.ReplyToAddress" /></summary>
        public const string ReplyToAddress = "ReplyToAddress";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.ReplyToName" /></summary>
        public const string ReplyToName = "ReplyToName";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.Subject" /></summary>
        public const string Subject = "Subject";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.TextBody" /></summary>
        public const string TextBody = "TextBody";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.HtmlBody" /></summary>
        public const string HtmlBody = "HtmlBody";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.TenantId" /></summary>
        public const string TenantId = "TenantId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.Created" /></summary>
        public const string Created = "Created";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.CreatedBy" /></summary>
        public const string CreatedBy = "CreatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.Updated" /></summary>
        public const string Updated = "Updated";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.UpdatedBy" /></summary>
        public const string UpdatedBy = "UpdatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.EmailTemplate.RowVersion" /></summary>
        public const string RowVersion = "RowVersion";
    }
    #endregion

}
