using System;

namespace InstructorIQ.Core.Data
{
    public interface ISupportSoftDelete
    {
        bool IsDeleted { get; set; }
    }
}