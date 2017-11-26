using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class InstructorOrganization
    {
        public InstructorOrganization()
        {
        }

        public Guid Id { get; set; }
        public Guid InstructorId { get; set; }
        public Guid OrganizationId { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Organization Organization { get; set; }
    }
}