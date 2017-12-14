using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class RefreshTokenMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.RefreshToken>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.RefreshToken> builder)
        {
            // table
            builder.ToTable("RefreshToken", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.TokenHashed)
                .IsRequired()
                .HasColumnName("TokenHashed")
                .HasMaxLength(256);
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId");
            builder.Property(t => t.UserName)
                .IsRequired()
                .HasColumnName("UserName")
                .HasMaxLength(256);
            builder.Property(t => t.ClientId)
                .HasColumnName("ClientId")
                .HasMaxLength(450);
            builder.Property(t => t.ProtectedTicket)
                .HasColumnName("ProtectedTicket");
            builder.Property(t => t.Issued)
                .IsRequired()
                .HasColumnName("Issued")
                .HasDefaultValueSql("(sysutcdatetime())");
            builder.Property(t => t.Expires)
                .HasColumnName("Expires");

            // Relationships
            builder.HasOne(t => t.User)
                .WithMany(t => t.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_RefreshToken_User_UserId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.RefreshToken> builder);

    }
}
