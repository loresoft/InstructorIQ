using System;

using Microsoft.AspNetCore.Http;

namespace InstructorIQ.Core.Multitenancy;

public static class HttpContextExtensions
{
    private const string TenantContextKey = "TenantContext";

    public static void SetTenantContext<TTenant>(this HttpContext context, TenantContext<TTenant> tenantContext)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));
        if (tenantContext == null)
            throw new ArgumentNullException(nameof(tenantContext));

        context.Items[TenantContextKey] = tenantContext;
    }

    public static TenantContext<TTenant> GetTenantContext<TTenant>(this HttpContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        return context.Items.TryGetValue(TenantContextKey, out var tenantContext)
            ? tenantContext as TenantContext<TTenant>
            : null;
    }

    public static TTenant GetTenant<TTenant>(this HttpContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        var tenantContext = GetTenantContext<TTenant>(context);

        return tenantContext != null
            ? tenantContext.Tenant
            : default(TTenant);
    }
}
