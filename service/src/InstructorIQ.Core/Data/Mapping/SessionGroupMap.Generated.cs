using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Mapping
{
    public partial class SessionGroupMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.SessionGroup>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.SessionGroup> builder)
        {
            // table
            builder.ToTable("SessionGroup", "dbo");

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
            builder.Property(t => t.GroupId)
                .IsRequired()
                .HasColumnName("GroupId");

            // Relationships
            builder.HasOne(t => t.Group)
                .WithMany(t => t.SessionGroups)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_SessionGroup_Group_GroupId");
            builder.HasOne(t => t.Session)
                .WithMany(t => t.SessionGroups)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK_SessionGroup_Session_SessionId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.SessionGroup> builder);

    }
}
