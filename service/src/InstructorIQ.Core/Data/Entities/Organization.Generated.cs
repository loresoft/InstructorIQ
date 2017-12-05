using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class Organization
    {
        public Organization()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            Groups = new HashSet<Group>();
            InstructorOrganizations = new HashSet<InstructorOrganization>();
            Locations = new HashSet<Location>();
            Sessions = new HashSet<Session>();
            Topics = new HashSet<Topic>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<InstructorOrganization> InstructorOrganizations { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}