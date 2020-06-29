using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class SessionCalendarModel : SessionReadModel
    {
        public string TopicDescription { get; set; }

        public string LocationAddressLine1 { get; set; }

        public string LocationCity { get; set; }

        public string LocationStateProvince { get; set; }

        public string LocationPostalCode { get; set; }

        public List<SessionInstructorModel> AdditionalInstructors { get; set; } = new List<SessionInstructorModel>();

    }
}