using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class UserMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.User> builder)
        {
            // table
            builder.ToTable("User", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.EmailAddress)
                .IsRequired()
                .HasColumnName("EmailAddress")
                .HasMaxLength(256);
            builder.Property(t => t.IsEmailAddressConfirmed)
                .IsRequired()
                .HasColumnName("IsEmailAddressConfirmed")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.DisplayName)
                .IsRequired()
                .HasColumnName("DisplayName")
                .HasMaxLength(256);
            builder.Property(t => t.PasswordHash)
                .HasColumnName("PasswordHash");
            builder.Property(t => t.PhoneNumber)
                .HasColumnName("PhoneNumber");
            builder.Property(t => t.IsPhoneNumberConfirmed)
                .IsRequired()
                .HasColumnName("IsPhoneNumberConfirmed")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.SecurityStamp)
                .HasColumnName("SecurityStamp");
            builder.Property(t => t.IsTwoFactorEnabled)
                .IsRequired()
                .HasColumnName("IsTwoFactorEnabled")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.AccessFailedCount)
                .IsRequired()
                .HasColumnName("AccessFailedCount")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.LockoutEnabled)
                .IsRequired()
                .HasColumnName("LockoutEnabled")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.LockoutEnd)
                .HasColumnName("LockoutEnd");
            builder.Property(t => t.Created)
                .IsRequired()
                .HasColumnName("Created")
                .HasDefaultValueSql("(sysutcdatetime())");
            builder.Property(t => t.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(100);
            builder.Property(t => t.Updated)
                .IsRequired()
                .HasColumnName("Updated")
                .HasDefaultValueSql("(sysutcdatetime())");
            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasMaxLength(100);
            builder.Property(t => t.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .HasColumnName("RowVersion")
                .HasMaxLength(8)
                .ValueGeneratedOnAddOrUpdate();

            // Relationships

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.User> builder);

    }
}
