using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping;

/// <summary>
/// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.TenantUserRole" />
/// </summary>
public partial class TenantUserRoleMap
    : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.TenantUserRole>
{
    /// <summary>
    /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.TenantUserRole" />
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.TenantUserRole> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("TenantUserRole", "IQ");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newsequentialid())");

        builder.Property(t => t.TenantId)
            .IsRequired()
            .HasColumnName("TenantId")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.UserId)
            .IsRequired()
            .HasColumnName("UserId")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.RoleId)
            .IsRequired()
            .HasColumnName("RoleId")
            .HasColumnType("uniqueidentifier");

        // relationships
        builder.HasOne(t => t.Tenant)
            .WithMany(t => t.TenantUserRoles)
            .HasForeignKey(d => d.TenantId)
            .HasConstraintName("FK_TenantUserRole_Tenant_TenantId");

        #endregion

        builder.HasOne(t => t.Role)
            .WithMany(t => t.TenantUserRoles)
            .HasForeignKey(d => d.RoleId)
            .HasConstraintName("FK_TenantUserRole_Role_RoleId");

        builder.HasOne(t => t.User)
            .WithMany(t => t.TenantUserRoles)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_TenantUserRole_User_UserId");
    }

    #region Generated Constants
    public readonly struct Table
    {
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.TenantUserRole" /></summary>
        public const string Schema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.TenantUserRole" /></summary>
        public const string Name = "TenantUserRole";
    }

    public readonly struct Columns
    {
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TenantUserRole.Id" /></summary>
        public const string Id = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TenantUserRole.TenantId" /></summary>
        public const string TenantId = "TenantId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TenantUserRole.UserId" /></summary>
        public const string UserId = "UserId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.TenantUserRole.RoleId" /></summary>
        public const string RoleId = "RoleId";
    }
    #endregion


}
