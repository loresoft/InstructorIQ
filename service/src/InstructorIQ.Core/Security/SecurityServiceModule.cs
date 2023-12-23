using Injectio.Attributes;

using InstructorIQ.Core.Data.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Security;

public class SecurityServiceModule
{

    [RegisterServices]
    public void Register(IServiceCollection services)
    {
        services.AddTransient<IUserClaimsPrincipalFactory<User>, UserClaimsPrincipalFactory>();
        services.AddTransient<UserClaimManager>();
    }
}
