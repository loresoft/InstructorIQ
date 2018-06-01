using System;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    public class UserLoginMappingProfile : AutoMapper.Profile
    {
        public UserLoginMappingProfile()
        {
            CreateMap<UserLogin, UserLoginReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}