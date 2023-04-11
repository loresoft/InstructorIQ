using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping;

/// <summary>
/// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.Discussion" />
/// </summary>
public partial class DiscussionMap
    : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Discussion>
{
    /// <summary>
    /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.Discussion" />
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Discussion> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("Discussion", "IQ");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newsequentialid())");

        builder.Property(t => t.TopicId)
            .IsRequired()
            .HasColumnName("TopicId")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.TenantId)
            .IsRequired()
            .HasColumnName("TenantId")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Message)
            .HasColumnName("Message")
            .HasColumnType("nvarchar(max)");

        builder.Property(t => t.MessageDate)
            .IsRequired()
            .HasColumnName("MessageDate")
            .HasColumnType("datetimeoffset")
            .HasDefaultValueSql("(sysutcdatetime())");

        builder.Property(t => t.EmailAddress)
            .IsRequired()
            .HasColumnName("EmailAddress")
            .HasColumnType("nvarchar(256)")
            .HasMaxLength(256);

        builder.Property(t => t.DisplayName)
            .IsRequired()
            .HasColumnName("DisplayName")
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
            .WithMany(t => t.Discussions)
            .HasForeignKey(d => d.TenantId)
            .HasConstraintName("FK_Discussion_Tenant_TenantId");

        builder.HasOne(t => t.Topic)
            .WithMany(t => t.Discussions)
            .HasForeignKey(d => d.TopicId)
            .HasConstraintName("FK_Discussion_Topic_TopicId");

        #endregion

        builder.Property(t => t.PeriodStart)
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(t => t.PeriodEnd)
            .ValueGeneratedOnAddOrUpdate();
    }

    #region Generated Constants
    public struct Table
    {
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Discussion" /></summary>
        public const string Schema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Discussion" /></summary>
        public const string Name = "Discussion";
    }

    public struct Columns
    {
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.Id" /></summary>
        public const string Id = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.TopicId" /></summary>
        public const string TopicId = "TopicId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.TenantId" /></summary>
        public const string TenantId = "TenantId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.Message" /></summary>
        public const string Message = "Message";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.MessageDate" /></summary>
        public const string MessageDate = "MessageDate";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.EmailAddress" /></summary>
        public const string EmailAddress = "EmailAddress";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.DisplayName" /></summary>
        public const string DisplayName = "DisplayName";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.UserAgent" /></summary>
        public const string UserAgent = "UserAgent";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.Browser" /></summary>
        public const string Browser = "Browser";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.OperatingSystem" /></summary>
        public const string OperatingSystem = "OperatingSystem";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.DeviceFamily" /></summary>
        public const string DeviceFamily = "DeviceFamily";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.DeviceBrand" /></summary>
        public const string DeviceBrand = "DeviceBrand";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.DeviceModel" /></summary>
        public const string DeviceModel = "DeviceModel";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.IpAddress" /></summary>
        public const string IpAddress = "IpAddress";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.Created" /></summary>
        public const string Created = "Created";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.CreatedBy" /></summary>
        public const string CreatedBy = "CreatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.Updated" /></summary>
        public const string Updated = "Updated";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.UpdatedBy" /></summary>
        public const string UpdatedBy = "UpdatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.RowVersion" /></summary>
        public const string RowVersion = "RowVersion";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.PeriodStart" /></summary>
        public const string PeriodStart = "PeriodStart";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Discussion.PeriodEnd" /></summary>
        public const string PeriodEnd = "PeriodEnd";
    }
    #endregion

}
