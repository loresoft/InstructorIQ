using System;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    public class OrganizationMappingProfile : AutoMapper.Profile
    {
        public OrganizationMappingProfile()
        {
            CreateMap<OrganizationCreateModel, Organization>();

            CreateMap<OrganizationUpdateModel, Organization>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

            CreateMap<Organization, OrganizationReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}