using AutoMapper;

using InstructorIQ.Core.Domain.Models;

namespace InstructorIQ.Core.Domain.Mapping;

public class MemberProfile : Profile
{
    public MemberProfile()
    {
        CreateMap<Data.Entities.User, MemberReadModel>();

        CreateMap<Data.Entities.User, MemberUpdateModel>();

        CreateMap<Data.Entities.User, MemberImportModel>();

        CreateMap<MemberUpdateModel, Data.Entities.User>();

        CreateMap<MemberReadModel, MemberUpdateModel>();

        CreateMap<MemberReadModel, MemberImportModel>();

        CreateMap<Data.Entities.User, MemberDropdownModel>()
            .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id.ToString().ToLowerInvariant()))
            .ForMember(d => d.Text, opt => opt.MapFrom(s => s.SortName));

    }
}
