using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class User
    {
        public User()
        {
            AccessFailedCount = 0;
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            Instructors = new HashSet<Instructor>();
            RefreshTokens = new HashSet<RefreshToken>();
            UserLogins = new HashSet<UserLogin>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public bool IsEmailAddressConfirmed { get; set; }
        public string DisplayName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public int AccessFailedCount { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public DateTimeOffset? LastLogin { get; set; }
        public Guid? LastOrganizationId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual Organization LastOrganization { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}