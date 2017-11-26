using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class UserLoginMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.UserLogin>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.UserLogin> builder)
        {
            // table
            builder.ToTable("UserLogin", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.LoginProvider)
                .IsRequired()
                .HasColumnName("LoginProvider")
                .HasMaxLength(450);
            builder.Property(t => t.ProviderKey)
                .IsRequired()
                .HasColumnName("ProviderKey")
                .HasMaxLength(450);
            builder.Property(t => t.ProviderDisplayName)
                .HasColumnName("ProviderDisplayName");
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            // Relationships
            builder.HasOne(t => t.User)
                .WithMany(t => t.UserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserLogin_User_UserId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.UserLogin> builder);

    }
}
