using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class LocationMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Location>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Location> builder)
        {
            // table
            builder.ToTable("Location", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(256);
            builder.Property(t => t.Description)
                .HasColumnName("Description");
            builder.Property(t => t.AddressLine1)
                .HasColumnName("AddressLine1")
                .HasMaxLength(256);
            builder.Property(t => t.AddressLine2)
                .HasColumnName("AddressLine2")
                .HasMaxLength(256);
            builder.Property(t => t.AddressLine3)
                .HasColumnName("AddressLine3")
                .HasMaxLength(256);
            builder.Property(t => t.City)
                .HasColumnName("City")
                .HasMaxLength(150);
            builder.Property(t => t.StateProvince)
                .HasColumnName("StateProvince")
                .HasMaxLength(150);
            builder.Property(t => t.PostalCode)
                .HasColumnName("PostalCode")
                .HasMaxLength(50);
            builder.Property(t => t.Latitude)
                .HasColumnName("Latitude");
            builder.Property(t => t.Longitude)
                .HasColumnName("Longitude");
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
                .WithMany(t => t.Locations)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_Location_Organization_OrganizationId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Location> builder);

    }
}
