using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="UserLogin"/> .
    /// </summary>
    public class UserLoginProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginProfile"/> class.
        /// </summary>
        public UserLoginProfile()
        {
            CreateMap<UserLogin, UserLoginReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }

    }
}
