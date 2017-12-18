using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Profiles
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<TopicCreateModel, Topic>();

            CreateMap<TopicUpdateModel, Topic>();

            CreateMap<Topic, TopicReadModel>();
        }
    }
}