using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class EmailDeliveryMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.EmailDelivery>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.EmailDelivery> builder)
        {
            // table
            builder.ToTable("EmailDelivery", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.IsProcessing)
                .IsRequired()
                .HasColumnName("IsProcessing")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.IsDelivered)
                .IsRequired()
                .HasColumnName("IsDelivered")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.Delivered)
                .HasColumnName("Delivered");
            builder.Property(t => t.Attempts)
                .IsRequired()
                .HasColumnName("Attempts")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.LastAttempt)
                .HasColumnName("LastAttempt");
            builder.Property(t => t.NextAttempt)
                .HasColumnName("NextAttempt");
            builder.Property(t => t.SmtpLog)
                .HasColumnName("SmtpLog");
            builder.Property(t => t.Error)
                .HasColumnName("Error");
            builder.Property(t => t.From)
                .HasColumnName("From")
                .HasMaxLength(265);
            builder.Property(t => t.To)
                .HasColumnName("To")
                .HasMaxLength(265);
            builder.Property(t => t.Subject)
                .HasColumnName("Subject")
                .HasMaxLength(265);
            builder.Property(t => t.MimeMessage)
                .HasColumnName("MimeMessage");
            builder.Property(t => t.OrganizationId)
                .HasColumnName("OrganizationId");
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
            builder.HasOne(t => t.Organization)
                .WithMany(t => t.EmailDeliveries)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_EmailDelivery_Organization_OrganizationId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.EmailDelivery> builder);

    }
}
