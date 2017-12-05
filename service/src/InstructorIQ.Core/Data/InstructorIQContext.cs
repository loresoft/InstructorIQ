using System;
using InstructorIQ.Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data
{
    public partial class InstructorIQContext
    {
        partial void InitializeMapping(ModelBuilder builder)
        {

            // Customize the ASP.NET Identity model
            builder.Entity<User>(entity =>
            {
                entity.ToTable("User", "dbo");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "dbo");
            });

            builder.Entity<IdentityUserRole<Guid>>(entity =>
            {
                entity.ToTable("UserRole", "dbo");
            });

            builder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable("UserClaim", "dbo");
            });

            builder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.ToTable("UserLogin", "dbo");
            });

            builder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable("RoleClaim", "dbo");

            });

            builder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable("UserToken", "dbo");
            });
        }
    }
}