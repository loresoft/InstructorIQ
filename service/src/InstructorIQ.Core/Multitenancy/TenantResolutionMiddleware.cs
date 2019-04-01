using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Multitenancy
{
    public class TenantResolutionMiddleware<TTenant>
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public TenantResolutionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            if (next == null)
                throw new ArgumentNullException(nameof(next));

            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));

            _next = next;
            _logger = loggerFactory.CreateLogger<TenantResolutionMiddleware<TTenant>>();
        }

        public async Task Invoke(HttpContext context, ITenantContextResolver<TTenant> tenantContextResolver)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (tenantContextResolver == null)
                throw new ArgumentNullException(nameof(tenantContextResolver));

            _logger.LogDebug("Resolving TenantContext using {loggerType}.", tenantContextResolver.GetType().Name);

            var tenantContext = await tenantContextResolver.ResolveAsync(context);

            if (tenantContext != null)
            {
                _logger.LogDebug("TenantContext Resolved. Adding to HttpContext.");
                context.SetTenantContext(tenantContext);
            }
            else
            {
                // return 404?
                _logger.LogDebug("TenantContext Not Resolved.");
            }

            await _next.Invoke(context);
        }
    }
}