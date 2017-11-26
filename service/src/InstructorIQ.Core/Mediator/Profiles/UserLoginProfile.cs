using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
{
    public class UserLoginProfile : Profile
    {
        public UserLoginProfile()
        {
            CreateMap<UserLoginCreateModel, UserLogin>();

            CreateMap<UserLoginUpdateModel, UserLogin>();

            CreateMap<UserLogin, UserLoginReadModel>();
        }
    }
}