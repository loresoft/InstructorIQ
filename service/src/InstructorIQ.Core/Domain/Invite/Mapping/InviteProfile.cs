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
            CreateMap<Invite, InviteReadModel>();
            CreateMap<InviteCreateModel, Invite>();
        }

    }
}
