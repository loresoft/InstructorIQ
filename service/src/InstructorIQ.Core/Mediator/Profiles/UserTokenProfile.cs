using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
{
    public class UserTokenProfile : Profile
    {
        public UserTokenProfile()
        {
            CreateMap<UserTokenCreateModel, UserToken>();

            CreateMap<UserTokenUpdateModel, UserToken>();

            CreateMap<UserToken, UserTokenReadModel>();
        }
    }
}