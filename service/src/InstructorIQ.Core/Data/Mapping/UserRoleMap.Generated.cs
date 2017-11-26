using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class UserRoleMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.UserRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.UserRole> builder)
        {
            // table
            builder.ToTable("UserRole", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId");
            builder.Property(t => t.OrganizationId)
                .IsRequired()
                .HasColumnName("OrganizationId");
            builder.Property(t => t.RoleId)
                .IsRequired()
                .HasColumnName("RoleId");

            // Relationships
            builder.HasOne(t => t.Organization)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_UserRole_Organization_OrganizationId");
            builder.HasOne(t => t.Role)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_UserRole_Role_RoleId");
            builder.HasOne(t => t.User)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserRole_User_UserId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.UserRole> builder);

    }
}
