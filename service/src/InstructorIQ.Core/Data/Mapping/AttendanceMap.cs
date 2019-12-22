using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.Attendance" />
    /// </summary>
    public partial class AttendanceMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Attendance>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.Attendance" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Attendance> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Attendance", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.SessionId)
                .IsRequired()
                .HasColumnName("SessionId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.Attended)
                .IsRequired()
                .HasColumnName("Attended")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("(sysutcdatetime())");

            builder.Property(t => t.AttendedBy)
                .IsRequired()
                .HasColumnName("AttendedBy")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.Signature)
                .HasColumnName("Signature")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.SignatureType)
                .HasColumnName("SignatureType")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

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
            builder.HasOne(t => t.Session)
                .WithMany(t => t.Attendances)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK_Attendance_Session_SessionId");

            builder.HasOne(t => t.Tenant)
                .WithMany(t => t.Attendances)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_Attendance_Tenant_TenantId");

            #endregion
        }

        #region Generated Constants
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Attendance" /></summary>
        public const string TableSchema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Attendance" /></summary>
        public const string TableName = "Attendance";

        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.Id" /></summary>
        public const string ColumnId = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.SessionId" /></summary>
        public const string ColumnSessionId = "SessionId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.Attended" /></summary>
        public const string ColumnAttended = "Attended";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.AttendedBy" /></summary>
        public const string ColumnAttendedBy = "AttendedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.Signature" /></summary>
        public const string ColumnSignature = "Signature";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.SignatureType" /></summary>
        public const string ColumnSignatureType = "SignatureType";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.TenantId" /></summary>
        public const string ColumnTenantId = "TenantId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.Created" /></summary>
        public const string ColumnCreated = "Created";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.CreatedBy" /></summary>
        public const string ColumnCreatedBy = "CreatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.Updated" /></summary>
        public const string ColumnUpdated = "Updated";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.UpdatedBy" /></summary>
        public const string ColumnUpdatedBy = "UpdatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Attendance.RowVersion" /></summary>
        public const string ColumnRowVersion = "RowVersion";
        #endregion
    }
}
