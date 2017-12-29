using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Models
{
    public class HistoryRecordProfile : Profile
    {
        public HistoryRecordProfile()
        {
            CreateMap<HistoryRecordCreateModel, HistoryRecord>();

            CreateMap<HistoryRecordUpdateModel, HistoryRecord>();

            CreateMap<HistoryRecord, HistoryRecordReadModel>();
        }
    }
}