using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Profiles
{
    public class EmailTemplateProfile : Profile
    {
        public EmailTemplateProfile()
        {
            CreateMap<EmailTemplateCreateModel, EmailTemplate>();

            CreateMap<EmailTemplateUpdateModel, EmailTemplate>();

            CreateMap<EmailTemplate, EmailTemplateReadModel>();
        }
    }
}