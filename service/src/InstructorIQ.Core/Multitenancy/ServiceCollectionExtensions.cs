using System;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Multitenancy;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMultitenancy<TTenant, TResolver>(this IServiceCollection services)
        where TResolver : class, ITenantContextResolver<TTenant>
        where TTenant : class
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services.AddTransient<ITenantContextResolver<TTenant>, TResolver>();

        // No longer registered by default
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // Make Tenant and TenantContext injectable
        services.AddTransient(prov => prov.GetService<IHttpContextAccessor>()?.HttpContext?.GetTenantContext<TTenant>());
        services.AddTransient(prov => prov.GetService<TenantContext<TTenant>>()?.Tenant);

        // Make ITenant injectable for handling null injection, similar to IOptions
        services.AddTransient<ITenant<TTenant>>(prov => new TenantValue<TTenant>(prov.GetService<TTenant>()));

        return services;
    }
}
