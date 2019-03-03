using System;
using System.Collections.Generic;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class InstructorServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.Instructor, InstructorReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.Instructor, InstructorReadModel, InstructorCreateModel, InstructorUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<InstructorDropdownQuery, IReadOnlyCollection<InstructorDropdownModel>>, InstructorDropdownQueryHandler>();
        }
    }
}