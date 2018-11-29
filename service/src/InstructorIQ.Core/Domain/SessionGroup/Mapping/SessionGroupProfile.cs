using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="SessionGroup"/> .
    /// </summary>
    public class SessionGroupProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionGroupProfile"/> class.
        /// </summary>
        public SessionGroupProfile()
        {
            CreateMap<SessionGroupCreateModel, SessionGroup>();

            CreateMap<SessionGroupUpdateModel, SessionGroup>();

            CreateMap<SessionGroup, SessionGroupReadModel>();
        }
    }
}
