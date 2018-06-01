using System;

namespace InstructorIQ.Core.Data.Definitions
{
    public interface ISupportSoftDelete
    {
        bool IsDeleted { get; set; }
    }
}