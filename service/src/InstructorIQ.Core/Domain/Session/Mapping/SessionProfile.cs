using System;
using System.Linq;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="Session"/> .
    /// </summary>
    public class SessionProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionProfile"/> class.
        /// </summary>
        public SessionProfile()
        {
            CreateMap<SessionCreateModel, Session>();

            CreateMap<SessionUpdateModel, Session>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

            CreateMap<Session, SessionReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
                .ForMember(d => d.TopicTitle, opt => opt.MapFrom(s => s.Topic.Title))
                .ForMember(d => d.IsRequired, opt => opt.MapFrom(s => s.Topic.IsRequired))
                .ForMember(d => d.TenantName, opt => opt.MapFrom(s => s.Tenant.Name))
                .ForMember(d => d.TenantTimeZone, opt => opt.MapFrom(s => s.Tenant.TimeZone))
                .ForMember(d => d.LocationName, opt => opt.MapFrom(s => s.Location.Name))
                .ForMember(d => d.GroupName, opt => opt.MapFrom(s => s.Group.Name))
                .ForMember(d => d.LeadInstructorName, opt => opt.MapFrom(s => s.LeadInstructor.DisplayName));

            CreateMap<Session, SessionCalendarModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
                .ForMember(d => d.TopicTitle, opt => opt.MapFrom(s => s.Topic.Title))
                .ForMember(d => d.IsRequired, opt => opt.MapFrom(s => s.Topic.IsRequired))
                .ForMember(d => d.TenantName, opt => opt.MapFrom(s => s.Tenant.Name))
                .ForMember(d => d.LocationName, opt => opt.MapFrom(s => s.Location.Name))
                .ForMember(d => d.GroupName, opt => opt.MapFrom(s => s.Group.Name))
                .ForMember(d => d.LeadInstructorName, opt => opt.MapFrom(s => s.LeadInstructor.DisplayName))
                .ForMember(d => d.AdditionalInstructors, opt => opt.MapFrom(s => s.SessionInstructors.Select(i => i.Instructor.DisplayName)));

            CreateMap<Session, SessionUpdateModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }

    }
}
