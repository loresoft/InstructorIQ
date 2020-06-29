using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="TopicInstructor"/> .
    /// </summary>
    public partial class TopicInstructorProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopicInstructorProfile"/> class.
        /// </summary>
        public TopicInstructorProfile()
        {
            CreateMap<InstructorIQ.Core.Data.Entities.TopicInstructor, InstructorIQ.Core.Domain.Models.TopicInstructorReadModel>();

            CreateMap<InstructorIQ.Core.Domain.Models.TopicInstructorCreateModel, InstructorIQ.Core.Data.Entities.TopicInstructor>();

            CreateMap<InstructorIQ.Core.Data.Entities.TopicInstructor, InstructorIQ.Core.Domain.Models.TopicInstructorUpdateModel>();

            CreateMap<InstructorIQ.Core.Domain.Models.TopicInstructorUpdateModel, InstructorIQ.Core.Data.Entities.TopicInstructor>();

            CreateMap<InstructorIQ.Core.Domain.Models.TopicInstructorReadModel, InstructorIQ.Core.Domain.Models.TopicInstructorUpdateModel>();

        }

    }
}
