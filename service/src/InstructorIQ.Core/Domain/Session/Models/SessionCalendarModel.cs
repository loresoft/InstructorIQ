using System;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.Pkcs;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class SessionCalendarModel : SessionReadModel
    {
        public string LocationAddressLine1 { get; set; }

        public string LocationCity { get; set; }

        public string LocationStateProvince { get; set; }

        public string LocationPostalCode { get; set; }


        public List<SessionInstructorModel> AdditionalInstructors { get; set; } = new List<SessionInstructorModel>();
    }
}