using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Profiles
{
    public class SessionInstructorProfile : Profile
    {
        public SessionInstructorProfile()
        {
            CreateMap<SessionInstructorCreateModel, SessionInstructor>();

            CreateMap<SessionInstructorUpdateModel, SessionInstructor>();

            CreateMap<SessionInstructor, SessionInstructorReadModel>();
        }
    }
}