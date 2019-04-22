using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="Discussion"/> .
    /// </summary>
    public partial class DiscussionProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscussionProfile"/> class.
        /// </summary>
        public DiscussionProfile()
        {
            CreateMap<InstructorIQ.Core.Data.Entities.Discussion, InstructorIQ.Core.Domain.Models.DiscussionReadModel>();
            CreateMap<InstructorIQ.Core.Domain.Models.DiscussionCreateModel, InstructorIQ.Core.Data.Entities.Discussion>();
            CreateMap<InstructorIQ.Core.Data.Entities.Discussion, InstructorIQ.Core.Domain.Models.DiscussionUpdateModel>();
            CreateMap<InstructorIQ.Core.Domain.Models.DiscussionUpdateModel, InstructorIQ.Core.Data.Entities.Discussion>();
        }

    }
}
