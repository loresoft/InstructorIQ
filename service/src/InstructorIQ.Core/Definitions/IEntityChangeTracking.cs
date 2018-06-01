using System;

namespace InstructorIQ.Core.Data.Definitions
{
    public interface IEntityChangeTracking
    {
        DateTimeOffset Created { get; set; }
        string CreatedBy { get; set; }

        DateTimeOffset Updated { get; set; }
        string UpdatedBy { get; set; }
    }
}