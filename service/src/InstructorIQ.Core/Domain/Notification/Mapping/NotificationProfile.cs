using System;

using AutoMapper;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping;

/// <summary>
/// Mapper class for entity <see cref="Notification"/> .
/// </summary>
public class NotificationProfile
    : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationProfile"/> class.
    /// </summary>
    public NotificationProfile()
    {
        CreateMap<Notification, NotificationReadModel>();

        CreateMap<NotificationCreateModel, Notification>();

        CreateMap<Notification, NotificationUpdateModel>();

        CreateMap<NotificationUpdateModel, Notification>();
    }

}
