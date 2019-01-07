using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.RefreshToken" />
    /// </summary>
    public class RefreshTokenMap
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

            builder.Property(t => t.TokenHashed)
                .IsRequired()
                .HasColumnName("TokenHashed")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier");

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
            builder.HasOne(t => t.User)
                .WithMany(t => t.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_RefreshToken_User_UserId");

            #endregion
        }

    }
}
