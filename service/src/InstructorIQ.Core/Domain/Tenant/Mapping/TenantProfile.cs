using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    /// <summary>
    /// Mapper class for entity <see cref="Tenant"/> .
    /// </summary>
    public class TenantProfile
        : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantProfile"/> class.
        /// </summary>
        public TenantProfile()
        {
            CreateMap<TenantCreateModel, Tenant>();

            CreateMap<TenantUpdateModel, Tenant>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

            CreateMap<Tenant, TenantReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<Tenant, TenantUpdateModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<Tenant, TenantDropdownModel>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Text, opt => opt.MapFrom(s => s.Name));

        }

    }
}
