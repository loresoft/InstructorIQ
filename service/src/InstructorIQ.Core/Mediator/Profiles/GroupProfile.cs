using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupCreateModel, Group>();

            CreateMap<GroupUpdateModel, Group>();

            CreateMap<Group, GroupReadModel>();
        }
    }
}