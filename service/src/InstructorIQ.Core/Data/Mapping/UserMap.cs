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
        }

    }
}
