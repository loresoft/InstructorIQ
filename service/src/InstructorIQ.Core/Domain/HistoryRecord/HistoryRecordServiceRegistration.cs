using System;

using Injectio.Attributes;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain;

public class HistoryRecordServiceRegistration : DomainServiceRegistrationBase
{

    [RegisterServices]
    public override void Register(IServiceCollection services)
    {
        RegisterEntityQuery<Guid, HistoryRecord, HistoryRecordReadModel>(services);
    }
}
