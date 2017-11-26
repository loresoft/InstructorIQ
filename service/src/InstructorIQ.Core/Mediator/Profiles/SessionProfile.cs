using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<SessionCreateModel, Session>();

            CreateMap<SessionUpdateModel, Session>();

            CreateMap<Session, SessionReadModel>();
        }
    }
}