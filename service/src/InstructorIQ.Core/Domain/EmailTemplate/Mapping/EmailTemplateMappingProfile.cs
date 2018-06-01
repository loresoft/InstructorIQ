using System;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    public class EmailTemplateMappingProfile : AutoMapper.Profile
    {
        public EmailTemplateMappingProfile()
        {
            CreateMap<EmailTemplateCreateModel, EmailTemplate>();

            CreateMap<EmailTemplateUpdateModel, EmailTemplate>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

            CreateMap<EmailTemplate, EmailTemplateReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}