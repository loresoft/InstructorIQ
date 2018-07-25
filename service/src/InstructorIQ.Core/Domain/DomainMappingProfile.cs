using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace InstructorIQ.Core.Domain
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<byte[], string>().ConvertUsing(Convert.ToBase64String);
            CreateMap<string, byte[]>().ConvertUsing(Convert.FromBase64String);
        }
    }
}
