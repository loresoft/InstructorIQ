using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="InviteRole"/> .
    /// </summary>
    public partial class InviteRoleProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InviteRoleProfile"/> class.
        /// </summary>
        public InviteRoleProfile()
        {
            CreateMap<InstructorIQ.Core.Data.Entities.InviteRole, InstructorIQ.Core.Domain.Models.InviteRoleReadModel>();
            CreateMap<InstructorIQ.Core.Domain.Models.InviteRoleCreateModel, InstructorIQ.Core.Data.Entities.InviteRole>();
        }

    }
}
