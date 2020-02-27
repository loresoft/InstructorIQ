using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="Attendance"/> .
    /// </summary>
    public class AttendanceProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttendanceProfile"/> class.
        /// </summary>
        public AttendanceProfile()
        {
            CreateMap<AttendanceCreateModel, Attendance>();

            CreateMap<AttendanceUpdateModel, Attendance>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

            CreateMap<Attendance, AttendanceReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
                .ForMember(d => d.TopicId, opt => opt.MapFrom(s => s.Session.TopicId))
                .ForMember(d => d.TopicTitle, opt => opt.MapFrom(s => s.Session.Topic.Title))
                .ForMember(d => d.IsRequired, opt => opt.MapFrom(s => s.Session.Topic.IsRequired))
                .ForMember(d => d.LocationId, opt => opt.MapFrom(s => s.Session.LocationId))
                .ForMember(d => d.LocationName, opt => opt.MapFrom(s => s.Session.Location.Name));

            CreateMap<Attendance, AttendanceSessionModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
                .ForMember(d => d.TopicId, opt => opt.MapFrom(s => s.Session.TopicId))
                .ForMember(d => d.TopicTitle, opt => opt.MapFrom(s => s.Session.Topic.Title))
                .ForMember(d => d.IsRequired, opt => opt.MapFrom(s => s.Session.Topic.IsRequired))
                .ForMember(d => d.LocationId, opt => opt.MapFrom(s => s.Session.LocationId))
                .ForMember(d => d.LocationName, opt => opt.MapFrom(s => s.Session.Location.Name))
                .ForMember(d => d.GroupId, opt => opt.MapFrom(s => s.Session.GroupId))
                .ForMember(d => d.GroupName, opt => opt.MapFrom(s => s.Session.Group.Name))
                .ForMember(d => d.StartDate, opt => opt.MapFrom(s => s.Session.StartDate))
                .ForMember(d => d.StartTime, opt => opt.MapFrom(s => s.Session.StartTime))
                .ForMember(d => d.EndDate, opt => opt.MapFrom(s => s.Session.EndDate))
                .ForMember(d => d.EndTime, opt => opt.MapFrom(s => s.Session.EndTime));

            CreateMap<Attendance, AttendanceUpdateModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }

    }
}
