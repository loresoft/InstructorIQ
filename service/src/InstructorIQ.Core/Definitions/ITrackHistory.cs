using System;

namespace InstructorIQ.Core.Definitions
{
    public interface ITrackHistory
    {
        DateTime PeriodStart { get; set; }

        DateTime PeriodEnd { get; set; }
    }
}
