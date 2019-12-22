using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.RefreshToken" />
    /// </summary>
    public partial class RefreshTokenMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.RefreshToken>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.RefreshToken" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.RefreshToken> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("RefreshToken", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.TokenHash)
                .IsRequired()
                .HasColumnName("TokenHash")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.UserName)
                .IsRequired()
                .HasColumnName("UserName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.ClientId)
                .HasColumnName("ClientId")
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450);

            builder.Property(t => t.ProtectedTicket)
                .HasColumnName("ProtectedTicket")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.Issued)
                .IsRequired()
                .HasColumnName("Issued")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("(sysutcdatetime())");

            builder.Property(t => t.Expires)
                .HasColumnName("Expires")
                .HasColumnType("datetimeoffset");

            // relationships
            #endregion
        }

        #region Generated Constants
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.RefreshToken" /></summary>
        public const string TableSchema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.RefreshToken" /></summary>
        public const string TableName = "RefreshToken";

        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.Id" /></summary>
        public const string ColumnId = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.TokenHash" /></summary>
        public const string ColumnTokenHash = "TokenHash";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.UserName" /></summary>
        public const string ColumnUserName = "UserName";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.ClientId" /></summary>
        public const string ColumnClientId = "ClientId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.ProtectedTicket" /></summary>
        public const string ColumnProtectedTicket = "ProtectedTicket";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.Issued" /></summary>
        public const string ColumnIssued = "Issued";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.Expires" /></summary>
        public const string ColumnExpires = "Expires";
        #endregion

    }
}
