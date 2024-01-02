using System;
using System.Linq;

using AutoMapper;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping;

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

        CreateMap<TopicUpdateModel, Topic>();

        CreateMap<Topic, TopicReadModel>()
            .ForMember(d => d.TenantName, opt => opt.MapFrom(s => s.Tenant.Name))
            .ForMember(d => d.LeadInstructorName, opt => opt.MapFrom(s => s.LeadInstructor.DisplayName))
            .ForMember(d => d.LeadInstructorEmail, opt => opt.MapFrom(s => s.LeadInstructor.Email))
            .ForMember(d => d.SessionCount, opt => opt.MapFrom(s => s.Sessions.Count()));

        CreateMap<Topic, TopicListModel>()
            .ForMember(d => d.TenantName, opt => opt.MapFrom(s => s.Tenant.Name))
            .ForMember(d => d.LeadInstructorName, opt => opt.MapFrom(s => s.LeadInstructor.DisplayName))
            .ForMember(d => d.LeadInstructorEmail, opt => opt.MapFrom(s => s.LeadInstructor.Email))
            .ForMember(d => d.SessionCount, opt => opt.MapFrom(s => s.Sessions.Count()));

        CreateMap<Topic, TopicUpdateModel>();

        CreateMap<TopicReadModel, TopicUpdateModel>();

        CreateMap<Topic, TopicMultipleUpdateModel>();

        CreateMap<Topic, TopicDropdownModel>()
            .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Text, opt => opt.MapFrom(s => s.Title));

    }

}
