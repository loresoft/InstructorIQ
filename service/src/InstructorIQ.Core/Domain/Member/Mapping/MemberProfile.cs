using AutoMapper;
using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Mapping
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Data.Entities.User, MemberReadModel>();

            CreateMap<Data.Entities.User, MemberUpdateModel>();

            CreateMap<Data.Entities.User, MemberImportModel>();

            CreateMap<MemberUpdateModel, Data.Entities.User>();
        }
    }
}
