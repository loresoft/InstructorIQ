using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="Group"/> .
    /// </summary>
    public class GroupProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupProfile"/> class.
        /// </summary>
        public GroupProfile()
        {
            CreateMap<GroupCreateModel, Group>();

            CreateMap<GroupUpdateModel, Group>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

            CreateMap<Group, GroupReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
                .ForMember(d => d.TenantName, opt => opt.MapFrom(s => s.Tenant.Name));

            CreateMap<Group, GroupUpdateModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<Group, GroupDropdownModel>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id.ToString().ToLowerInvariant()))
                .ForMember(d => d.Text, opt => opt.MapFrom(s => s.Name));
        }

    }
}
