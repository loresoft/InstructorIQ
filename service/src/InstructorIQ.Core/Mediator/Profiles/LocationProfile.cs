using System;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationCreateModel, Location>();

            CreateMap<LocationUpdateModel, Location>();

            CreateMap<Location, LocationReadModel>();
        }
    }
}