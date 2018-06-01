using System;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    public class SessionGroupMappingProfile : AutoMapper.Profile
    {
        public SessionGroupMappingProfile()
        {
            CreateMap<SessionGroupCreateModel, SessionGroup>();

            CreateMap<SessionGroupUpdateModel, SessionGroup>();

            CreateMap<SessionGroup, SessionGroupReadModel>();
        }
    }
}