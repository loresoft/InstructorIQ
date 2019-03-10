using System;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class SessionCalendarModel : SessionReadModel
    {
        public string TopicTitle { get; set; }

        public bool IsRequired { get; set; }
    }
}