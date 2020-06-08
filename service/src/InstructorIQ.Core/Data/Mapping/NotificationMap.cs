using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.Notification" />
    /// </summary>
    public partial class NotificationMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Notification>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.Notification" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Notification> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Notification", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.Type)
                .IsRequired()
                .HasColumnName("Type")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.Message)
                .HasColumnName("Message")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.UserName)
                .IsRequired()
                .HasColumnName("UserName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.Read)
                .HasColumnName("Read")
                .HasColumnType("datetimeoffset");

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

            // relationships
            builder.HasOne(t => t.Tenant)
                .WithMany(t => t.Notifications)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_Notification_Tenant_TenantId");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Notification" /></summary>
            public const string Schema = "IQ";
            /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Notification" /></summary>
            public const string Name = "Notification";
        }

        public struct Columns
        {
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Notification.Id" /></summary>
            public const string Id = "Id";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Notification.Type" /></summary>
            public const string Type = "Type";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Notification.Message" /></summary>
            public const string Message = "Message";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Notification.UserName" /></summary>
            public const string UserName = "UserName";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Notification.Read" /></summary>
            public const string Read = "Read";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Notification.TenantId" /></summary>
            public const string TenantId = "TenantId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Notification.Created" /></summary>
            public const string Created = "Created";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Notification.CreatedBy" /></summary>
            public const string CreatedBy = "CreatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Notification.Updated" /></summary>
            public const string Updated = "Updated";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Notification.UpdatedBy" /></summary>
            public const string UpdatedBy = "UpdatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Notification.RowVersion" /></summary>
            public const string RowVersion = "RowVersion";
        }
        #endregion

    }
}
