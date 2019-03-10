using System;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.Pkcs;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class SessionCalendarModel : SessionReadModel
    {
        public string TopicTitle { get; set; }

        public bool IsRequired { get; set; }

        public List<string> AdditionalInstructors { get; set; } = new List<string>();
    }
}