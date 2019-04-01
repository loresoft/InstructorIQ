using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="InstructorRole"/> .
    /// </summary>
    public partial class InstructorRoleProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstructorRoleProfile"/> class.
        /// </summary>
        public InstructorRoleProfile()
        {
            CreateMap<InstructorIQ.Core.Data.Entities.InstructorRole, InstructorIQ.Core.Domain.Models.InstructorRoleReadModel>();
            CreateMap<InstructorIQ.Core.Domain.Models.InstructorRoleCreateModel, InstructorIQ.Core.Data.Entities.InstructorRole>();
            CreateMap<InstructorIQ.Core.Data.Entities.InstructorRole, InstructorIQ.Core.Domain.Models.InstructorRoleUpdateModel>();
            CreateMap<InstructorIQ.Core.Domain.Models.InstructorRoleUpdateModel, InstructorIQ.Core.Data.Entities.InstructorRole>();
        }

    }
}
