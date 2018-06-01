using System;
using System.Collections.Generic;
using InstructorIQ.Core.Domain.Authentication.Commands;
using InstructorIQ.Core.Domain.Authentication.Handlers;
using InstructorIQ.Core.Security;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class AuthenticationServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.TryAddTransient<IRequestHandler<AuthenticateCommand, TokenResponse>, AuthenticateCommandHandler>();
        }
    }
}
