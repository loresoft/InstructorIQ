using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="SessionInstructor"/> .
    /// </summary>
    public class SessionInstructorProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionInstructorProfile"/> class.
        /// </summary>
        public SessionInstructorProfile()
        {
            CreateMap<SessionInstructorCreateModel, SessionInstructor>();

            CreateMap<SessionInstructorUpdateModel, SessionInstructor>();

            CreateMap<SessionInstructor, SessionInstructorReadModel>();
        }

    }
}
