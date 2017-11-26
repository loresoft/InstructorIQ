using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class Topic
    {
        public Topic()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            Sessions = new HashSet<Session>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Objectives { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid? LeadInstructorId { get; set; }
        public short CalendarYear { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
        public virtual Instructor LeadInstructor { get; set; }
        public virtual Organization Organization { get; set; }
    }
}