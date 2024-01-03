using System;
using System.Linq;

using AutoMapper;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Mapping;

/// <summary>
/// Mapper class for entity <see cref="SignUpTopic"/> .
/// </summary>
public partial class SignUpTopicProfile
    : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SignUpTopicProfile"/> class.
    /// </summary>
    public SignUpTopicProfile()
    {
        CreateMap<SignUpTopic, SignUpTopicReadModel>()
            .ForMember(d => d.TopicTitle, opt => opt.MapFrom(s => s.Topic.Title))
            .ForMember(d => d.TopicCalendarYear, opt => opt.MapFrom(s => s.Topic.CalendarYear))
            .ForMember(d => d.TopicTargetMonth, opt => opt.MapFrom(s => s.Topic.TargetMonth))
            .ForMember(d => d.TopicInstructorSlots, opt => opt.MapFrom(s => s.Topic.InstructorSlots))
            .ForMember(d => d.TopicInstructors, opt => opt.MapFrom(s => s.Topic.TopicInstructors.Select(i => new TopicInstructorReadModel
            {
                Id = i.Id,
                InstructorId = i.InstructorId,
                TopicId = i.TopicId,
                InstructorRoleId = i.InstructorRoleId,
                Created = i.Created,
                CreatedBy = i.CreatedBy,
                Updated = i.Updated,
                UpdatedBy = i.UpdatedBy,
                PeriodStart = i.PeriodStart,
                PeriodEnd = i.PeriodEnd,
                InstructorDisplayName = i.Instructor.DisplayName,
                InstructorSortName = i.Instructor.SortName,
                InstructorGivenName = i.Instructor.GivenName,
                InstructorFamilyName = i.Instructor.FamilyName,
                InstructorEmailAddress = i.Instructor.Email
            })));

        CreateMap<SignUpTopicCreateModel, SignUpTopic>();

        CreateMap<SignUpTopic, SignUpTopicUpdateModel>()
            .ForMember(d => d.TopicTitle, opt => opt.MapFrom(s => s.Topic.Title))
            .ForMember(d => d.TopicCalendarYear, opt => opt.MapFrom(s => s.Topic.CalendarYear))
            .ForMember(d => d.TopicTargetMonth, opt => opt.MapFrom(s => s.Topic.TargetMonth))
            .ForMember(d => d.TopicInstructorSlots, opt => opt.MapFrom(s => s.Topic.InstructorSlots));

        CreateMap<SignUpTopicUpdateModel, SignUpTopic>();

        CreateMap<SignUpTopicReadModel, SignUpTopicUpdateModel>();

    }

}
