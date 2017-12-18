using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Profiles
{
    public class SessionGroupProfile : Profile
    {
        public SessionGroupProfile()
        {
            CreateMap<SessionGroupCreateModel, SessionGroup>();

            CreateMap<SessionGroupUpdateModel, SessionGroup>();

            CreateMap<SessionGroup, SessionGroupReadModel>();
        }
    }
}