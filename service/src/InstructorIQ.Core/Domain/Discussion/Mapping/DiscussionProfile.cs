using System;

using AutoMapper;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping;

/// <summary>
/// Mapper class for entity <see cref="Discussion"/> .
/// </summary>
public class DiscussionProfile
    : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DiscussionProfile"/> class.
    /// </summary>
    public DiscussionProfile()
    {
        CreateMap<DiscussionCreateModel, Discussion>();

        CreateMap<DiscussionUpdateModel, Discussion>();

        CreateMap<Discussion, DiscussionReadModel>()
            .ForMember(d => d.TopicTitle, opt => opt.MapFrom(s => s.Topic.Title))
            .ForMember(d => d.TenantName, opt => opt.MapFrom(s => s.Tenant.Name));

        CreateMap<Discussion, DiscussionUpdateModel>();

        CreateMap<UserAgentModel, DiscussionCreateModel>();
    }

}
