using System;

using AutoMapper;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Mapping;

/// <summary>
/// Mapper class for entity <see cref="AuthenticationEvent"/> .
/// </summary>
public partial class AuthenticationEventProfile
    : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationEventProfile"/> class.
    /// </summary>
    public AuthenticationEventProfile()
    {
        CreateMap<InstructorIQ.Core.Data.Entities.AuthenticationEvent, InstructorIQ.Core.Domain.Models.AuthenticationEventReadModel>();
        CreateMap<InstructorIQ.Core.Domain.Models.AuthenticationEventCreateModel, InstructorIQ.Core.Data.Entities.AuthenticationEvent>();
        CreateMap<InstructorIQ.Core.Domain.Models.AuthenticationEventUpdateModel, InstructorIQ.Core.Data.Entities.AuthenticationEvent>();
    }

}
