using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="SessionInstructor"/> .
    /// </summary>
    public partial class SessionInstructorProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionInstructorProfile"/> class.
        /// </summary>
        public SessionInstructorProfile()
        {
            CreateMap<InstructorIQ.Core.Data.Entities.SessionInstructor, InstructorIQ.Core.Domain.Models.SessionInstructorReadModel>();

            CreateMap<InstructorIQ.Core.Domain.Models.SessionInstructorCreateModel, InstructorIQ.Core.Data.Entities.SessionInstructor>();

            CreateMap<InstructorIQ.Core.Data.Entities.SessionInstructor, InstructorIQ.Core.Domain.Models.SessionInstructorUpdateModel>();

            CreateMap<InstructorIQ.Core.Domain.Models.SessionInstructorUpdateModel, InstructorIQ.Core.Data.Entities.SessionInstructor>();

            CreateMap<InstructorIQ.Core.Domain.Models.SessionInstructorReadModel, InstructorIQ.Core.Domain.Models.SessionInstructorUpdateModel>();

        }

    }
}
