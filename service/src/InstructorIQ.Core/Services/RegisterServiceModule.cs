using System;

using Azure.Data.Tables;

using EntityChange;

using InstructorIQ.Core.Options;

using MediatR.CommandQuery.Definitions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

using SendGrid.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Services
{
    public class RegisterServiceModule
    {

        [RegisterServices]
        public void Register(IServiceCollection services)
        {
            services.TryAddTransient<IEmailTemplateService, EmailTemplateService>();
            services.TryAddTransient<ITenantResolver<Guid>, TenantResolver>();
            services.TryAddTransient<IImportProcessService, ImportProcessService>();

            services.TryAddSingleton<IStorageService, StorageService>();
            services.TryAddSingleton<IEntityComparer, EntityComparer>();
            services.TryAddSingleton<IHtmlService, HtmlService>();
            services.TryAddSingleton<IStateService, CookieStateService>();
            services.TryAddSingleton<ICleanupService, CleanupService>();

            services.TryAddSingleton<TableServiceClient>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("StorageAccount");
                return new TableServiceClient(connectionString);
            });

            services.AddMemoryCache();

            services.AddSendGrid((serviceProvider, options) =>
            {
                var configuration = serviceProvider.GetRequiredService<IOptions<SendGridConfiguration>>();
                options.ApiKey = configuration.Value.ApiKey;
            });

        }
    }
}
