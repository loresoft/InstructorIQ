using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRoleCreateModel, UserRole>();

            CreateMap<UserRoleUpdateModel, UserRole>();

            CreateMap<UserRole, UserRoleReadModel>();
        }
    }
}