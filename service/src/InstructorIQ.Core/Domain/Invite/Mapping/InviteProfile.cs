using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="Invite"/> .
    /// </summary>
    public partial class InviteProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InviteProfile"/> class.
        /// </summary>
        public InviteProfile()
        {
            CreateMap<InstructorIQ.Core.Data.Entities.Invite, InstructorIQ.Core.Domain.Models.InviteReadModel>();
            CreateMap<InstructorIQ.Core.Domain.Models.InviteCreateModel, InstructorIQ.Core.Data.Entities.Invite>();
        }

    }
}
