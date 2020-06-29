using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class SignUpTopicServiceRegistration : DomainServiceRegistrationBase
    {
         public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.SignUpTopic, SignUpTopicReadModel>(services);
            RegisterEntityQuery<Guid, Data.Entities.SignUpTopic, SignUpTopicUpdateModel>(services);

            RegisterEntityCommand<Guid, Data.Entities.SignUpTopic, SignUpTopicReadModel, SignUpTopicCreateModel, SignUpTopicUpdateModel>(services);

        }

    }
}
