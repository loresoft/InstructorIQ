using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class Instructor
    {
        public Instructor()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            InstructorOrganizations = new HashSet<InstructorOrganization>();
            LeadSessions = new HashSet<Session>();
            SessionInstructors = new HashSet<SessionInstructor>();
            LeadTopics = new HashSet<Topic>();
        }

        public Guid Id { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public string BusinessPhone { get; set; }
        public Guid? UserId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<InstructorOrganization> InstructorOrganizations { get; set; }
        public virtual ICollection<Session> LeadSessions { get; set; }
        public virtual ICollection<SessionInstructor> SessionInstructors { get; set; }
        public virtual ICollection<Topic> LeadTopics { get; set; }
    }
}