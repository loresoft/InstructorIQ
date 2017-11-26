using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class RoleClaimMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.RoleClaim>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.RoleClaim> builder)
        {
            // table
            builder.ToTable("RoleClaim", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.ClaimType)
                .HasColumnName("ClaimType");
            builder.Property(t => t.ClaimValue)
                .HasColumnName("ClaimValue");
            builder.Property(t => t.RoleId)
                .IsRequired()
                .HasColumnName("RoleId");

            // Relationships
            builder.HasOne(t => t.Role)
                .WithMany(t => t.RoleClaims)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_RoleClaim_Role_RoleId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.RoleClaim> builder);

    }
}
