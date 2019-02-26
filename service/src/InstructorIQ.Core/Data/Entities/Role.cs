using EntityFrameworkCore.CommandQuery.Definitions;
using Microsoft.AspNetCore.Identity;
using System;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'Role'.
    /// </summary>
    public class Role : IdentityRole<Guid>, IHaveIdentifier<Guid>
    {
        public Role()
        {
        }

        public Role(string roleName) : base(roleName)
        {
        }

        public string Description { get; set; }
    }
}
