using System;

using Injectio.Attributes;

using InstructorIQ.Core.Domain.Models;

using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain;

public class AuthenticationEventServiceRegistration : DomainServiceRegistrationBase
{

    [RegisterServices]
    public override void Register(IServiceCollection services)
    {
        RegisterEntityQuery<Guid, InstructorIQ.Core.Data.Entities.AuthenticationEvent, AuthenticationEventReadModel>(services);

        RegisterEntityCommand<Guid, InstructorIQ.Core.Data.Entities.AuthenticationEvent, AuthenticationEventReadModel, AuthenticationEventCreateModel, AuthenticationEventUpdateModel>(services);

    }

}
