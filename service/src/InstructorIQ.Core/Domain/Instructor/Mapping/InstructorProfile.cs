using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="Instructor"/> .
    /// </summary>
    public class InstructorProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstructorProfile"/> class.
        /// </summary>
        public InstructorProfile()
        {
            CreateMap<InstructorCreateModel, Instructor>();

            CreateMap<InstructorUpdateModel, Instructor>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

            CreateMap<Instructor, InstructorReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
                .ForMember(d => d.TenantName, opt => opt.MapFrom(s => s.Tenant.Name));
        }

    }
}
