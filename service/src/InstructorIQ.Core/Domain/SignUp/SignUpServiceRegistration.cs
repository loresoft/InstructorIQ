using System;

using Injectio.Attributes;

using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;

using MediatR;
using MediatR.CommandQuery.Models;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain;

public class SignUpServiceRegistration : DomainServiceRegistrationBase
{

    [RegisterServices]
    public override void Register(IServiceCollection services)
    {
        RegisterEntityQuery<Guid, Data.Entities.SignUp, SignUpReadModel>(services);
        RegisterEntityCommand<Guid, Data.Entities.SignUp, SignUpReadModel, SignUpCreateModel, SignUpUpdateModel>(services);

        services.TryAddTransient<IRequestHandler<SignUpCommand, CompleteModel>, SignUpCommandHandler>();
    }

}
