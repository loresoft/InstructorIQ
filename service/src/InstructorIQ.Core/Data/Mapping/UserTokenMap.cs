using System;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.UserToken" />
    /// </summary>
    public class UserTokenMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.UserToken>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.UserToken" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.UserToken> builder)
        {
            builder.ToTable("UserToken", "Identity");
        }

    }
}