using System;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Mapping;

/// <summary>
/// Allows configuration for an entity type <see cref="InstructorIQ.Core.Data.Entities.UserClaim" />
/// </summary>
public class UserClaimMap
    : IEntityTypeConfiguration<InstructorIQ.Core.Data.Entities.UserClaim>
{
    /// <summary>
    /// Configures the entity of type <see cref="InstructorIQ.Core.Data.Entities.UserClaim" />
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.UserClaim> builder)
    {
        builder.ToTable("UserClaim", "Identity");
    }

}
