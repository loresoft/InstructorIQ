using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Profiles
{
    public class InstructorOrganizationProfile : Profile
    {
        public InstructorOrganizationProfile()
        {
            CreateMap<InstructorOrganizationCreateModel, InstructorOrganization>();

            CreateMap<InstructorOrganizationUpdateModel, InstructorOrganization>();

            CreateMap<InstructorOrganization, InstructorOrganizationReadModel>();
        }
    }
}