using System;
using InstructorIQ.Core.Data.Definitions;

namespace InstructorIQ.Core.Mediator.Models
{
    public abstract class EntityCreateModel : IEntityChangeTracking
    {
        public Guid? Id { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;
        public string UpdatedBy { get; set; }
    }
}