using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.SessionGroup" />
    /// </summary>
    public class SessionGroupMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.SessionGroup>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.SessionGroup" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.SessionGroup> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("SessionGroup", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newsequentialid())");

            builder.Property(t => t.SessionId)
                .IsRequired()
                .HasColumnName("SessionId")
                .HasColumnType("uniqueidentifier");

            builder.Property(t => t.GroupId)
                .IsRequired()
                .HasColumnName("GroupId")
                .HasColumnType("uniqueidentifier");

            // relationships
            builder.HasOne(t => t.Group)
                .WithMany(t => t.SessionGroups)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_SessionGroup_Group_GroupId");

            builder.HasOne(t => t.Session)
                .WithMany(t => t.SessionGroups)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK_SessionGroup_Session_SessionId");

            #endregion
        }

    }
}
