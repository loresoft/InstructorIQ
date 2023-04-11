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

public class TopicInstructorServiceRegistration : DomainServiceRegistrationBase
{

    [RegisterServices]
    public override void Register(IServiceCollection services)
    {
        RegisterEntityQuery<Guid, Data.Entities.TopicInstructor, TopicInstructorReadModel>(services);

        RegisterEntityCommand<Guid, Data.Entities.TopicInstructor, TopicInstructorReadModel, TopicInstructorCreateModel, TopicInstructorUpdateModel>(services);

        services.TryAddTransient<IRequestHandler<TopicInstructorSignUpCommand, CompleteModel>, TopicInstructorSignUpHandler>();
    }

}
