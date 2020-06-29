using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Commands;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MediatR;
using MediatR.CommandQuery.Models;
using InstructorIQ.Core.Domain.Handlers;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class SignUpServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.SignUp, SignUpReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.SignUp, SignUpReadModel, SignUpCreateModel, SignUpUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<SignUpCommand, CompleteModel>, SignUpCommandHandler>();
        }

    }
}
