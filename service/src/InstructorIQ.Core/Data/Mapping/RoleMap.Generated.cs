using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class RoleMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.Role>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Role> builder)
        {
            // table
            builder.ToTable("Role", "dbo");

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

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Role> builder);

    }
}
