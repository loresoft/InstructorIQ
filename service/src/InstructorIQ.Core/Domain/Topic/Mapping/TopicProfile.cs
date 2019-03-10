using System;
using System.Linq;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="Topic"/> .
    /// </summary>
    public class TopicProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopicProfile"/> class.
        /// </summary>
        public TopicProfile()
        {
            CreateMap<TopicCreateModel, Topic>();

            CreateMap<TopicUpdateModel, Topic>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

            CreateMap<Topic, TopicReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
                .ForMember(d => d.TenantName, opt => opt.MapFrom(s => s.Tenant.Name))
                .ForMember(d => d.SessionCount, opt => opt.MapFrom(s => s.Sessions.Count()));

            CreateMap<Topic, TopicUpdateModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }

    }
}
