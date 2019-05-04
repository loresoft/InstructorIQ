using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.LinkToken" />
    /// </summary>
    public partial class LinkTokenMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.LinkToken>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.LinkToken" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.LinkToken> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("LinkToken", "IQ");

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

            builder.Property(t => t.Url)
                .IsRequired()
                .HasColumnName("Url")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.TenantId)
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.Issued)
                .IsRequired()
                .HasColumnName("Issued")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("(sysutcdatetime())");

            builder.Property(t => t.Expires)
                .HasColumnName("Expires")
                .HasColumnType("datetimeoffset");

            // relationships
            builder.HasOne(t => t.Tenant)
                .WithMany(t => t.LinkTokens)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_LinkToken_Tenant_TenantId");

            #endregion
        }

    }
}
