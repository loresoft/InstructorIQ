using System.Collections.Generic;
using InstructorIQ.Core.Data.Entities;
using KickStart.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InstructorIQ.Core.Security
{
    public class SecurityServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.AddScoped<IUserClaimsPrincipalFactory<User>, UserClaimsPrincipalFactory>();
            services.AddScoped<UserClaimManager>();
        }
    }
}
