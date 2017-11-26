using System;

namespace InstructorIQ.Core.Data
{
    public interface IEntityChangeTracking
    {
        DateTimeOffset Created { get; set; }
        string CreatedBy { get; set; }

        DateTimeOffset Updated { get; set; }
        string UpdatedBy { get; set; }

        Byte[] RowVersion { get; set; }
    }
}