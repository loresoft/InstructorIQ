using System;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{
    public class HistoryRecordMappingProfile : AutoMapper.Profile
    {
        public HistoryRecordMappingProfile()
        {
            CreateMap<HistoryRecordCreateModel, HistoryRecord>();

            CreateMap<HistoryRecordUpdateModel, HistoryRecord>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion))); ;

            CreateMap<HistoryRecord, HistoryRecordReadModel>()
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
        }
    }
}