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

        public async Task Invoke(HttpContext context, ITenantResolver<TTenant> tenantResolver)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (tenantResolver == null)
                throw new ArgumentNullException(nameof(tenantResolver));

            _logger.LogDebug("Resolving TenantContext using {loggerType}.", tenantResolver.GetType().Name);

            var tenantContext = await tenantResolver.ResolveAsync(context);

            if (tenantContext != null)
            {
                _logger.LogDebug("TenantContext Resolved. Adding to HttpContext.");
                context.SetTenantContext(tenantContext);
            }
            else
            {
                _logger.LogDebug("TenantContext Not Resolved.");
            }

            await _next.Invoke(context);
        }
    }
}