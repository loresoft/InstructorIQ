using System;
using EntityFrameworkCore.CommandQuery.Models;
using InstructorIQ.Core.Definitions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class TopicUpdateModel : EntityUpdateModel, IHaveOrganization
    {
        #region Generated Properties
        public string Title { get; set; }
        public string Description { get; set; }
        public string Objectives { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid? LeadInstructorId { get; set; }
        public short CalendarYear { get; set; }

        #endregion
    }
}