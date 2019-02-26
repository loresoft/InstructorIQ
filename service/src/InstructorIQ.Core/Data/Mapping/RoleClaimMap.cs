using System;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.RoleClaim" />
    /// </summary>
    public class RoleClaimMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.RoleClaim>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.RoleClaim" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.RoleClaim> builder)
        {
            builder.ToTable("RoleClaim", "Identity");
        }

    }
}