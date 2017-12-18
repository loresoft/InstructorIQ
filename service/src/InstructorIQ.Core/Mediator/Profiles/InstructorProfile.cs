using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Profiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<InstructorCreateModel, Instructor>();

            CreateMap<InstructorUpdateModel, Instructor>();

            CreateMap<Instructor, InstructorReadModel>();
        }
    }
}