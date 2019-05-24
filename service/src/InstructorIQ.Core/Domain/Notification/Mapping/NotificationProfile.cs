using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
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
            CreateMap<Notification, NotificationReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<NotificationCreateModel, Notification>();

            CreateMap<Notification, NotificationUpdateModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<NotificationUpdateModel, Notification>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
        }

    }
}
