using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class SessionInstructor
    {
        public SessionInstructor()
        {
        }

        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid InstructorId { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Session Session { get; set; }
    }
}