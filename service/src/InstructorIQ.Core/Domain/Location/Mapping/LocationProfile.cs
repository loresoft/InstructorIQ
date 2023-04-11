using System;

using AutoMapper;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping;

/// <summary>
/// Mapper class for entity <see cref="Location"/> .
/// </summary>
public class LocationProfile
    : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LocationProfile"/> class.
    /// </summary>
    public LocationProfile()
    {
        CreateMap<LocationCreateModel, Location>();

        CreateMap<LocationUpdateModel, Location>()
            .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));

        CreateMap<Location, LocationReadModel>()
            .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)))
            .ForMember(d => d.TenantName, opt => opt.MapFrom(s => s.Tenant.Name));

        CreateMap<Location, LocationUpdateModel>()
            .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

        CreateMap<Location, LocationDropdownModel>()
            .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id.ToString().ToLowerInvariant()))
            .ForMember(d => d.Text, opt => opt.MapFrom(s => s.Name));
    }

}
