using System;

namespace InstructorIQ.Core.Mediator.Models
{
    public abstract class EntityUpdateModel
    {
        public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;
        public string UpdatedBy { get; set; }
        public string RowVersion { get; set; }
    }
}