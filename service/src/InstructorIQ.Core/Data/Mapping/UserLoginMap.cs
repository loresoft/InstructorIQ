using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping
{
    /// <summary>
    /// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.UserLogin" />
    /// </summary>
    public class UserLoginMap
        : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.UserLogin>
    {
        /// <summary>
        /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.UserLogin" />
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.UserLogin> builder)
        {
            builder.ToTable("UserLogin", "Identity");
        }

    }
}
