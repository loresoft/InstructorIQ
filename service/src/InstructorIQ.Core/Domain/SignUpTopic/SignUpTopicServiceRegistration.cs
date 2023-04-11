using System;

using Injectio.Attributes;

using InstructorIQ.Core.Domain.Models;

using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain;

public class SignUpTopicServiceRegistration : DomainServiceRegistrationBase
{

    [RegisterServices]
    public override void Register(IServiceCollection services)
    {
        RegisterEntityQuery<Guid, Data.Entities.SignUpTopic, SignUpTopicReadModel>(services);
        RegisterEntityQuery<Guid, Data.Entities.SignUpTopic, SignUpTopicUpdateModel>(services);

        RegisterEntityCommand<Guid, Data.Entities.SignUpTopic, SignUpTopicReadModel, SignUpTopicCreateModel, SignUpTopicUpdateModel>(services);

    }

}
