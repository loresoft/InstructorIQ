using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUrlHelper(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddTransient(it =>
        {
            var urlHelperFactory = it.GetRequiredService<IUrlHelperFactory>();
            var httpContextAccessor = it.GetRequiredService<IHttpContextAccessor>();

            var httpContext = httpContextAccessor.HttpContext;
            var actionDescriptor = httpContext?.GetEndpoint()?.Metadata.GetMetadata<ActionDescriptor>() ?? new ActionDescriptor();
            var actionContext = new ActionContext(httpContext, httpContext?.GetRouteData() ?? new RouteData(), actionDescriptor);

            return urlHelperFactory.GetUrlHelper(actionContext);
        });

        return services;
    }
}
