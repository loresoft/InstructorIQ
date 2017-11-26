using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class InstructorOrganizationMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.InstructorOrganization>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.InstructorOrganization> builder)
        {
            // table
            builder.ToTable("InstructorOrganization", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.InstructorId)
                .IsRequired()
                .HasColumnName("InstructorId");
            builder.Property(t => t.OrganizationId)
                .IsRequired()
                .HasColumnName("OrganizationId");

            // Relationships
            builder.HasOne(t => t.Instructor)
                .WithMany(t => t.InstructorOrganizations)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK_InstructorOrganization_Instructor_InstructorId");
            builder.HasOne(t => t.Organization)
                .WithMany(t => t.InstructorOrganizations)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_InstructorOrganization_Organization_OrganizationId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.InstructorOrganization> builder);

    }
}
