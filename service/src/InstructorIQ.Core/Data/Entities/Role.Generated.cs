using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class Role
    {
        public Role()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            RoleClaims = new HashSet<RoleClaim>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }

        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}