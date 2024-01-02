using System;

using AutoMapper;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Mapping;

/// <summary>
/// Mapper class for entity <see cref="SignUp"/> .
/// </summary>
public partial class SignUpProfile
    : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SignUpProfile"/> class.
    /// </summary>
    public SignUpProfile()
    {
        CreateMap<SignUp, SignUpReadModel>();

        CreateMap<SignUpCreateModel, SignUp>();

        CreateMap<SignUp, SignUpUpdateModel>();

        CreateMap<SignUpUpdateModel, SignUp>();

        CreateMap<SignUpReadModel, SignUpUpdateModel>();

    }

}
