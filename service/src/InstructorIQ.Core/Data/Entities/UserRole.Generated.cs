using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class UserRole
    {
        public UserRole()
        {
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid RoleId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}