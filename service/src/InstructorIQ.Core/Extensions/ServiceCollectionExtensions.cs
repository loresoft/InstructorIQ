using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUrlHelper(this IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped(it => {
                var urlHelperFactory = it.GetRequiredService<IUrlHelperFactory>();
                var actionContextAccessor = it.GetRequiredService<IActionContextAccessor>();

                return urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
            });

            return services;
        }
    }
}
