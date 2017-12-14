using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
{
    public class EmailDeliveryProfile : Profile
    {
        public EmailDeliveryProfile()
        {
            CreateMap<EmailDeliveryCreateModel, EmailDelivery>();

            CreateMap<EmailDeliveryUpdateModel, EmailDelivery>();

            CreateMap<EmailDelivery, EmailDeliveryReadModel>();
        }
    }
}