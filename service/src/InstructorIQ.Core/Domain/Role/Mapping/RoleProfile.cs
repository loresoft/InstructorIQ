using AutoMapper;

using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Data.Entities.Role, RoleReadModel>();
    }
}
