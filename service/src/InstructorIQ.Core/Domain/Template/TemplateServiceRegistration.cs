using System;
using System.Collections.Generic;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class TemplateServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Template, TemplateReadModel>(services);
            RegisterEntityCommand<Guid, Template, TemplateReadModel, TemplateCreateModel, TemplateUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<TemplateDropdownQuery, IReadOnlyCollection<TemplateDropdownModel>>, TemplateDropdownQueryHandler>();
        }
    }
}
