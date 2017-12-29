using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class InstructorMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Instructor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Instructor> builder)
        {
            // table
            builder.ToTable("Instructor", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.GivenName)
                .IsRequired()
                .HasColumnName("GivenName")
                .HasMaxLength(256);
            builder.Property(t => t.MiddleName)
                .HasColumnName("MiddleName")
                .HasMaxLength(256);
            builder.Property(t => t.FamilyName)
                .IsRequired()
                .HasColumnName("FamilyName")
                .HasMaxLength(256);
            builder.Property(t => t.DisplayName)
                .IsRequired()
                .HasColumnName("DisplayName")
                .HasMaxLength(256);
            builder.Property(t => t.JobTitle)
                .HasColumnName("JobTitle")
                .HasMaxLength(256);
            builder.Property(t => t.EmailAddress)
                .IsRequired()
                .HasColumnName("EmailAddress")
                .HasMaxLength(256);
            builder.Property(t => t.MobilePhone)
                .IsRequired()
                .HasColumnName("MobilePhone")
                .HasMaxLength(50);
            builder.Property(t => t.BusinessPhone)
                .HasColumnName("BusinessPhone")
                .HasMaxLength(50);
            builder.Property(t => t.UserId)
                .HasColumnName("UserId");
            builder.Property(t => t.OrganizationId)
                .IsRequired()
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
                .WithMany(t => t.Instructors)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_Instructor_Organization_OrganizationId");
            builder.HasOne(t => t.User)
                .WithMany(t => t.Instructors)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Instructor_User_UserId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Instructor> builder);

    }
}
