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

            builder.Property(t => t.SortName)
                .HasColumnName("SortName")
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
                .WithMany(t => t.Instructors)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_Instructor_Tenant_TenantId");

            #endregion

            builder.Property(t => t.PeriodStart)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(t => t.PeriodEnd)
                .ValueGeneratedOnAddOrUpdate();
        }

        #region Generated Constants
        public struct Table
        {
            /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Instructor" /></summary>
            public const string Schema = "IQ";
            /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.Instructor" /></summary>
            public const string Name = "Instructor";
        }

        public struct Columns
        {
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.Id" /></summary>
            public const string Id = "Id";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.GivenName" /></summary>
            public const string GivenName = "GivenName";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.MiddleName" /></summary>
            public const string MiddleName = "MiddleName";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.FamilyName" /></summary>
            public const string FamilyName = "FamilyName";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.DisplayName" /></summary>
            public const string DisplayName = "DisplayName";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.SortName" /></summary>
            public const string SortName = "SortName";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.JobTitle" /></summary>
            public const string JobTitle = "JobTitle";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.EmailAddress" /></summary>
            public const string EmailAddress = "EmailAddress";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.MobilePhone" /></summary>
            public const string MobilePhone = "MobilePhone";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.BusinessPhone" /></summary>
            public const string BusinessPhone = "BusinessPhone";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.TenantId" /></summary>
            public const string TenantId = "TenantId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.Created" /></summary>
            public const string Created = "Created";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.CreatedBy" /></summary>
            public const string CreatedBy = "CreatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.Updated" /></summary>
            public const string Updated = "Updated";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.UpdatedBy" /></summary>
            public const string UpdatedBy = "UpdatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.RowVersion" /></summary>
            public const string RowVersion = "RowVersion";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.PeriodStart" /></summary>
            public const string PeriodStart = "PeriodStart";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.Instructor.PeriodEnd" /></summary>
            public const string PeriodEnd = "PeriodEnd";
        }
        #endregion

    }
}
