using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
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