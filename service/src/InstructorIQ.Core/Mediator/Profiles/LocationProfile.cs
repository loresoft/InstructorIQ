using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
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