using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class SessionInstructorMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.SessionInstructor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.SessionInstructor> builder)
        {
            // table
            builder.ToTable("SessionInstructor", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.SessionId)
                .IsRequired()
                .HasColumnName("SessionId");
            builder.Property(t => t.InstructorId)
                .IsRequired()
                .HasColumnName("InstructorId");

            // Relationships
            builder.HasOne(t => t.Instructor)
                .WithMany(t => t.SessionInstructors)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK_SessionInstructor_Instructor_InstructorId");
            builder.HasOne(t => t.Session)
                .WithMany(t => t.SessionInstructors)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK_SessionInstructor_Session_SessionId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.SessionInstructor> builder);

    }
}
