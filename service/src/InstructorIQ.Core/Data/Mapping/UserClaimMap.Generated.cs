using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class UserClaimMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.UserClaim>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.UserClaim> builder)
        {
            // table
            builder.ToTable("UserClaim", "dbo");

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
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            // Relationships
            builder.HasOne(t => t.User)
                .WithMany(t => t.UserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserClaim_User_UserId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.UserClaim> builder);

    }
}
