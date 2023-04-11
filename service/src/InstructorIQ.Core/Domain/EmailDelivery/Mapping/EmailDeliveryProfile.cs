using System;

using AutoMapper;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping;

/// <summary>
/// Mapper class for entity <see cref="EmailDelivery"/> .
/// </summary>
public class EmailDeliveryProfile
    : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmailDeliveryProfile"/> class.
    /// </summary>
    public EmailDeliveryProfile()
    {
        CreateMap<EmailDelivery, EmailDeliveryReadModel>()
            .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
    }

}
