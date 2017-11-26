using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class RoleClaim
    {
        public RoleClaim()
        {
        }

        public Guid Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}