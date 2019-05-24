using System;
using System.Collections.Generic;
using MediatR.CommandQuery.Definitions;
using KickStart.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Services
{
    public class RegisterServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.TryAddTransient<IEmailTemplateService, EmailTemplateService>();
            services.TryAddTransient<IEmailDeliveryService, EmailDeliveryService>();
            services.TryAddTransient<ITenantResolver<Guid>, TenantResolver>();
            services.TryAddTransient<IImportProcessService, ImportProcessService>();

            services.TryAddSingleton<IStorageService, StorageService>();
        }
    }
}
