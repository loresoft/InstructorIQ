using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber" />
    /// </summary>
    public partial class SessionReferenceNumberMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.SessionReferenceNumber>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.SessionReferenceNumber> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("SessionReferenceNumber", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.ReferenceNumber)
                .IsRequired()
                .HasColumnName("ReferenceNumber")
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);

            builder.Property(t => t.ReferenceType)
                .IsRequired()
                .HasColumnName("ReferenceType")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.SessionId)
                .IsRequired()
                .HasColumnName("SessionId")
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
                .WithMany(t => t.SessionReferenceNumbers)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK_SessionReferenceNumber_Session_[SessionId");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber" /></summary>
            public const string Schema = "IQ";
            /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber" /></summary>
            public const string Name = "SessionReferenceNumber";
        }

        public struct Columns
        {
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber.Id" /></summary>
            public const string Id = "Id";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber.ReferenceNumber" /></summary>
            public const string ReferenceNumber = "ReferenceNumber";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber.ReferenceType" /></summary>
            public const string ReferenceType = "ReferenceType";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber.SessionId" /></summary>
            public const string SessionId = "SessionId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber.Created" /></summary>
            public const string Created = "Created";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber.CreatedBy" /></summary>
            public const string CreatedBy = "CreatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber.Updated" /></summary>
            public const string Updated = "Updated";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber.UpdatedBy" /></summary>
            public const string UpdatedBy = "UpdatedBy";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SessionReferenceNumber.RowVersion" /></summary>
            public const string RowVersion = "RowVersion";
        }
        #endregion

    }
}
