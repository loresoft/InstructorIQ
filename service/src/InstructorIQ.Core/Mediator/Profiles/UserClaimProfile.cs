using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
{
    public class UserClaimProfile : Profile
    {
        public UserClaimProfile()
        {
            CreateMap<UserClaimCreateModel, UserClaim>();

            CreateMap<UserClaimUpdateModel, UserClaim>();

            CreateMap<UserClaim, UserClaimReadModel>();
        }
    }
}