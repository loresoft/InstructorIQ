using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
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