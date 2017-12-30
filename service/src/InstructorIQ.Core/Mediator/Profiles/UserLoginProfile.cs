﻿using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Profiles
{
    public class UserLoginProfile : Profile
    {
        public UserLoginProfile()
        {
            CreateMap<UserLogin, UserLoginReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}