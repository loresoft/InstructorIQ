using MediatR.CommandQuery.Definitions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'Role'.
    /// </summary>
    public class Role : IdentityRole<Guid>, IHaveIdentifier<Guid>
    {
        public Role() : this(null)
        {
        }

        public Role(string roleName) : base(roleName)
        {
            TenantUserRoles = new HashSet<TenantUserRole>();
        }

        public string Description { get; set; }

        public virtual ICollection<TenantUserRole> TenantUserRoles { get; set; }
    }
}
