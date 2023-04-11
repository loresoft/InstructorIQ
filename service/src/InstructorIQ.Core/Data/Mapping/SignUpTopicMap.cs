using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping;

/// <summary>
/// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic" />
/// </summary>
public partial class SignUpTopicMap
    : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.SignUpTopic>
{
    /// <summary>
    /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic" />
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.SignUpTopic> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("SignUpTopic", "IQ");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newsequentialid())");

        builder.Property(t => t.SignUpId)
            .IsRequired()
            .HasColumnName("SignUpId")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.TopicId)
            .IsRequired()
            .HasColumnName("TopicId")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Created)
            .IsRequired()
            .HasColumnName("Created")
            .HasColumnType("datetimeoffset")
            .HasDefaultValueSql("(sysutcdatetime())");

        builder.Property(t => t.CreatedBy)
            .HasColumnName("CreatedBy")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Updated)
            .IsRequired()
            .HasColumnName("Updated")
            .HasColumnType("datetimeoffset")
            .HasDefaultValueSql("(sysutcdatetime())");

        builder.Property(t => t.UpdatedBy)
            .HasColumnName("UpdatedBy")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.RowVersion)
            .IsRequired()
            .IsRowVersion()
            .HasColumnName("RowVersion")
            .HasColumnType("rowversion")
            .HasMaxLength(8)
            .ValueGeneratedOnAddOrUpdate();

        // relationships
        builder.HasOne(t => t.SignUp)
            .WithMany(t => t.SignUpTopics)
            .HasForeignKey(d => d.SignUpId)
            .HasConstraintName("FK_SignUpTopic_SignUp_SignUpId");

        builder.HasOne(t => t.Topic)
            .WithMany(t => t.SignUpTopics)
            .HasForeignKey(d => d.TopicId)
            .HasConstraintName("FK_SignUpTopic_Topic_TopicId");

        #endregion
    }

    #region Generated Constants
    public struct Table
    {
        /// <summary>Table Schema name constant for entity <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic" /></summary>
        public const string Schema = "IQ";
        /// <summary>Table Name constant for entity <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic" /></summary>
        public const string Name = "SignUpTopic";
    }

    public struct Columns
    {
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic.Id" /></summary>
        public const string Id = "Id";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic.SignUpId" /></summary>
        public const string SignUpId = "SignUpId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic.TopicId" /></summary>
        public const string TopicId = "TopicId";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic.Created" /></summary>
        public const string Created = "Created";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic.CreatedBy" /></summary>
        public const string CreatedBy = "CreatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic.Updated" /></summary>
        public const string Updated = "Updated";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic.UpdatedBy" /></summary>
        public const string UpdatedBy = "UpdatedBy";
        /// <summary>Column Name constant for property <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic.RowVersion" /></summary>
        public const string RowVersion = "RowVersion";
    }
    #endregion
}
