using System;

using AutoMapper;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping;

/// <summary>
/// Mapper class for entity <see cref="HistoryRecord"/> .
/// </summary>
public class HistoryRecordProfile
    : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HistoryRecordProfile"/> class.
    /// </summary>
    public HistoryRecordProfile()
    {
        CreateMap<HistoryRecord, HistoryRecordReadModel>();
    }

}
