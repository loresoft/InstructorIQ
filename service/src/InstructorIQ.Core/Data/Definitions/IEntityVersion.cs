using System;

namespace InstructorIQ.Core.Data.Definitions
{
    public interface IEntityVersion
    {
        Byte[] RowVersion { get; set; }
    }
}