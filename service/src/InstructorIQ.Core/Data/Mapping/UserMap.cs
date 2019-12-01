using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.User" />
    /// </summary>
    public class UserMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.User>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.User" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.User> builder)
        {
            builder.ToTable("User", "Identity");

            builder.Property(t => t.GivenName)
                .HasColumnName("GivenName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.MiddleName)
                .HasColumnName("MiddleName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.FamilyName)
                .HasColumnName("FamilyName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.DisplayName)
                .IsRequired()
                .HasColumnName("DisplayName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.SortName)
                .HasColumnName("SortName")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.JobTitle)
                .HasColumnName("JobTitle")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(t => t.LastTenantId)
                .HasColumnName("LastTenantId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.IsGlobalAdministrator)
                .IsRequired()
                .HasColumnName("IsGlobalAdministrator")
                .HasColumnType("bit");
        }

    }
}
