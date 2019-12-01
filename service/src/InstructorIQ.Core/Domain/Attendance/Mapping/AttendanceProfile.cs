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
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<Attendance, AttendanceSessionModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<Attendance, AttendanceUpdateModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }

    }
}
