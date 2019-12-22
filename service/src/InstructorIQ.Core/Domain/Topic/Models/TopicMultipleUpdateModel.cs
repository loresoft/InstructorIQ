using System;
using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class TopicMultipleUpdateModel 
        : EntityCreateModel<Guid>, IHaveTenant<Guid>
    {
        public Guid TenantId { get; set; }

        public string Title { get; set; }

        public short CalendarYear { get; set; }

        public short? TargetMonth { get; set; }
    }
}