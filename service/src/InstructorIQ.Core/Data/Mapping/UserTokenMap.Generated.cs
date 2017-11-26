using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class UserTokenMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.UserToken>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.UserToken> builder)
        {
            // table
            builder.ToTable("UserToken", "dbo");

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
            builder.Property(t => t.LoginProvider)
                .IsRequired()
                .HasColumnName("LoginProvider")
                .HasMaxLength(450);
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(450);
            builder.Property(t => t.Value)
                .HasColumnName("Value");

            // Relationships
            builder.HasOne(t => t.User)
                .WithMany(t => t.UserTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserToken_User_UserId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.UserToken> builder);

    }
}
