using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.InviteRole" />
    /// </summary>
    public partial class InviteRoleMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.InviteRole>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.InviteRole" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.InviteRole> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("InviteRole", "IQ");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.InviteId)
                .IsRequired()
                .HasColumnName("InviteId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.RoleName)
                .IsRequired()
                .HasColumnName("RoleName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            // relationships
            builder.HasOne(t => t.Invite)
                .WithMany(t => t.InviteRoles)
                .HasForeignKey(d => d.InviteId)
                .HasConstraintName("FK_InviteRole_Invite_InviteId");

            #endregion
        }

    }
}
