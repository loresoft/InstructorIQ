using System;
using MediatR.CommandQuery.Definitions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class SessionInstructorModel : IHaveIdentifier<Guid>,  ITrackUpdated, ITrackHistory
    {
        public Guid Id { get; set; }

        public Guid SessionId { get; set; }

        public Guid InstructorId { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public DateTimeOffset Updated { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }
    }
}