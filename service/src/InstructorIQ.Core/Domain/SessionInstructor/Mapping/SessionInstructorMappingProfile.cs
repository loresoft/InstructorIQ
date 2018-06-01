using System;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    public class SessionInstructorMappingProfile : AutoMapper.Profile
    {
        public SessionInstructorMappingProfile()
        {
            CreateMap<SessionInstructorCreateModel, SessionInstructor>();

            CreateMap<SessionInstructorUpdateModel, SessionInstructor>();

            CreateMap<SessionInstructor, SessionInstructorReadModel>();
        }
    }
}