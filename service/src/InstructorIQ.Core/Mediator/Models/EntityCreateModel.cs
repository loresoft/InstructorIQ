using System;

namespace InstructorIQ.Core.Mediator.Models
{
    public abstract class EntityCreateModel
    {
        public Guid? Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}