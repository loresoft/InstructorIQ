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
        public struct Table
        {
            /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.RefreshToken" /></summary>
            public const string Schema = "IQ";
            /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.RefreshToken" /></summary>
            public const string Name = "RefreshToken";
        }

        public struct Columns
        {
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.Id" /></summary>
            public const string Id = "Id";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.TokenHash" /></summary>
            public const string TokenHash = "TokenHash";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.UserName" /></summary>
            public const string UserName = "UserName";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.ClientId" /></summary>
            public const string ClientId = "ClientId";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.ProtectedTicket" /></summary>
            public const string ProtectedTicket = "ProtectedTicket";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.Issued" /></summary>
            public const string Issued = "Issued";
            /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.RefreshToken.Expires" /></summary>
            public const string Expires = "Expires";
        }
        #endregion

    }
}
