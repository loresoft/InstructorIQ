using System;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    public class SessionMappingProfile : AutoMapper.Profile
    {
        public SessionMappingProfile()
        {
            CreateMap<SessionCreateModel, Session>();

            CreateMap<SessionUpdateModel, Session>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

            CreateMap<Session, SessionReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
                .ForMember(d => d.OrganizationName, opt => opt.MapFrom(s => s.Organization.Name));
        }
    }
}