using System;
using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class TopicListModel : EntityReadModel<Guid>, IHaveTenant<Guid>
    {
        public string Title { get; set; }

        public string Summary { get; set; }

        public short CalendarYear { get; set; }

        public short? TargetMonth { get; set; }

        public string TenantName { get; set; }

        public string LeadInstructorName { get; set; }

        public int SessionCount { get; set; }


        public bool IsRequired { get; set; }

        public bool IsPublished { get; set; }


        public Guid TenantId { get; set; }

        public Guid? LeadInstructorId { get; set; }
    }
}