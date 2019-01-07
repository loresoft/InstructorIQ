using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.SessionInstructor" />
    /// </summary>
    public class SessionInstructorMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.SessionInstructor>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.SessionInstructor" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.SessionInstructor> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("SessionInstructor", "IQ");

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

            builder.Property(t => t.InstructorId)
                .IsRequired()
                .HasColumnName("InstructorId")
                .HasColumnType("uniqueidentifier");

            // relationships
            builder.HasOne(t => t.Instructor)
                .WithMany(t => t.SessionInstructors)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK_SessionInstructor_Instructor_InstructorId");

            builder.HasOne(t => t.Session)
                .WithMany(t => t.SessionInstructors)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK_SessionInstructor_Session_SessionId");

            #endregion
        }

    }
}
