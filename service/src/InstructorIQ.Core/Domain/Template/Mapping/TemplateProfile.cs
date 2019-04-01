using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="Template"/> .
    /// </summary>
    public partial class TemplateProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateProfile"/> class.
        /// </summary>
        public TemplateProfile()
        {
            CreateMap<TemplateCreateModel, Template>();

            CreateMap<TemplateUpdateModel, Template>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

            CreateMap<Template, TemplateReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<Template, TemplateUpdateModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<Template, TemplateDropdownModel>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Text, opt => opt.MapFrom(s => s.Name));
        }

    }
}
