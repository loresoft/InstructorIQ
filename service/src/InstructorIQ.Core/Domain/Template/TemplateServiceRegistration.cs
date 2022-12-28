using System;
using System.Collections.Generic;

using Injectio.Attributes;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Handlers;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR;
using MediatR.CommandQuery.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class TemplateServiceRegistration : DomainServiceRegistrationBase
    {

        [RegisterServices]
        public override void Register(IServiceCollection services)
        {
            RegisterEntityQuery<Guid, Template, TemplateReadModel>(services);
            RegisterEntityCommand<Guid, Template, TemplateReadModel, TemplateCreateModel, TemplateUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<TemplateDropdownQuery, IReadOnlyCollection<TemplateDropdownModel>>, TemplateDropdownQueryHandler>();

            services.AddEntityQueries<InstructorIQContext, Template, Guid, TemplateEditorModel>();
        }
    }
}
