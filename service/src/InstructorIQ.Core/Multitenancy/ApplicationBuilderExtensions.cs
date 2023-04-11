using System;

using Microsoft.AspNetCore.Builder;

namespace InstructorIQ.Core.Multitenancy;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseMultitenancy<TTenant>(this IApplicationBuilder app)
    {
        if (app == null)
            throw new ArgumentNullException(nameof(app));

        return app.UseMiddleware<TenantResolutionMiddleware<TTenant>>();
    }
}
