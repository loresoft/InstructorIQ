using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Profiles
{
    public class EmailDeliveryProfile : Profile
    {
        public EmailDeliveryProfile()
        {
            CreateMap<EmailDelivery, EmailDeliveryReadModel>();
        }
    }
}