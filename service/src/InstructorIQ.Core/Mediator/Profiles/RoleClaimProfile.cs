using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
{
    public class RoleClaimProfile : Profile
    {
        public RoleClaimProfile()
        {
            CreateMap<RoleClaimCreateModel, RoleClaim>();

            CreateMap<RoleClaimUpdateModel, RoleClaim>();

            CreateMap<RoleClaim, RoleClaimReadModel>();
        }
    }
}