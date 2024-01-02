using System;

using AutoMapper;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping;

/// <summary>
/// Mapper class for entity <see cref="EmailTemplate"/> .
/// </summary>
public class EmailTemplateProfile
    : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmailTemplateProfile"/> class.
    /// </summary>
    public EmailTemplateProfile()
    {
        CreateMap<EmailTemplateCreateModel, EmailTemplate>();

        CreateMap<EmailTemplateUpdateModel, EmailTemplate>();

        CreateMap<EmailTemplate, EmailTemplateReadModel>();

        CreateMap<EmailTemplateReadModel, EmailTemplateUpdateModel>();
    }

}
