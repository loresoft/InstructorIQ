using System;
using System.Collections.Generic;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using MediatR.CommandQuery.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class TopicInstructorServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.TopicInstructor, TopicInstructorReadModel>(services);

            RegisterEntityCommand<Guid, Data.Entities.TopicInstructor, TopicInstructorReadModel, TopicInstructorCreateModel, TopicInstructorUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<TopicInstructorSignUpCommand, CompleteModel>, TopicInstructorSignUpHandler>();
        }

    }
}
