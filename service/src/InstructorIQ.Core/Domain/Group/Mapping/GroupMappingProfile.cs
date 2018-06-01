using System;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    public class GroupMappingProfile : AutoMapper.Profile
    {
        public GroupMappingProfile()
        {
            CreateMap<GroupCreateModel, Group>();

            CreateMap<GroupUpdateModel, Group>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion))); ;

            CreateMap<Group, GroupReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}