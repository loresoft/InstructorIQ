using System;

namespace InstructorIQ.Core.Domain.Models
{
    public class SessionFrequentTimeModel
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Count { get; set; }
    }
}
