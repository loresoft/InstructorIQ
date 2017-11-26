using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class Session
    {
        public Session()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            SessionGroups = new HashSet<SessionGroup>();
            SessionInstructors = new HashSet<SessionInstructor>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid TopicId { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? LeadInstructorId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }

        public virtual Instructor LeadInstructor { get; set; }
        public virtual Location Location { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ICollection<SessionGroup> SessionGroups { get; set; }
        public virtual ICollection<SessionInstructor> SessionInstructors { get; set; }
    }
}