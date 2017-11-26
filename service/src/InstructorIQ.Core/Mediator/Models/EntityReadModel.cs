using System;

namespace InstructorIQ.Core.Mediator.Models
{
    public abstract class EntityReadModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;
        public string UpdatedBy { get; set; }
        public string RowVersion { get; set; }
    }
}