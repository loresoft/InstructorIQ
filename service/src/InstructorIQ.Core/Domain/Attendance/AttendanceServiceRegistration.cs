using System;
using System.Collections.Generic;

using Injectio.Attributes;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain;

public class AttendanceServiceRegistration : DomainServiceRegistrationBase
{
    [RegisterServices]
    public override void Register(IServiceCollection services)
    {
        RegisterEntityQuery<Guid, Attendance, AttendanceReadModel>(services);
        RegisterEntityQuery<Guid, Attendance, AttendanceSessionModel>(services);

        RegisterEntityCommand<Guid, Attendance, AttendanceReadModel, AttendanceCreateModel, AttendanceUpdateModel>(services);
        RegisterEntityCommand<Guid, Attendance, AttendanceSessionModel, AttendanceCreateModel, AttendanceUpdateModel>(services);

        services.TryAddTransient<IRequestHandler<AttendanceSessionQuery, IReadOnlyCollection<AttendanceSessionModel>>, AttendanceSessionQueryHandler>();
    }
}
