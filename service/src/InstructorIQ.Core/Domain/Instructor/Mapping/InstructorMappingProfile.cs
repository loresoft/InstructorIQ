using System;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    public class InstructorMappingProfile : AutoMapper.Profile
    {
        public InstructorMappingProfile()
        {
            CreateMap<InstructorCreateModel, Instructor>();

            CreateMap<InstructorUpdateModel, Instructor>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

            CreateMap<Instructor, InstructorReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
                .ForMember(d => d.OrganizationName, opt => opt.MapFrom(s => s.Organization.Name));
        }
    }
}