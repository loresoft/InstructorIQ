using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class SessionGroup
    {
        public SessionGroup()
        {
        }

        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Session Session { get; set; }
    }
}