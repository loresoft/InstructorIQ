using Injectio.Attributes;

using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;

using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Domain.LinkToken;

public class LoginLinkServiceRegistration : DomainServiceRegistrationBase
{

    [RegisterServices]
    public override void Register(IServiceCollection services)
    {
        services.TryAddTransient<IRequestHandler<LinkTokenCreateCommand, LinkTokenReadModel>, LinkTokenCreateCommandHandler>();
        services.TryAddTransient<IRequestHandler<LinkTokenValidateCommand, LinkTokenReadModel>, LinkTokenValidateCommandHandler>();
    }
}
