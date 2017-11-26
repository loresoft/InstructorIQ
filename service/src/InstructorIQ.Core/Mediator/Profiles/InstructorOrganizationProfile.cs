using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
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