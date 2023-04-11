using System;
using System.Security.Claims;
using System.Security.Principal;

using InstructorIQ.Core.Security;

namespace InstructorIQ.Core.Tests;

public class MockPrincipal
{
    static MockPrincipal()
    {
        Default = CreatePrincipal("test@mailinator.com", "Test User", Data.Constants.User.Test, Data.Constants.Tenant.Test, "Test Organization");
        GlobalAdmin = CreatePrincipal("support@InstructorIQ.com", "InstructorIQ Support", Data.Constants.User.Support, Data.Constants.Tenant.Demo, "Demo Organization", true);
    }


    public static IPrincipal Default { get; }

    public static IPrincipal GlobalAdmin { get; }


    public static ClaimsPrincipal CreatePrincipal(string email, string name, Guid userId, Guid organizationId, string organizationName, bool isGlobalAdmin = false)
    {
        var claimsIdentity = new ClaimsIdentity("Identity.Application", ClaimTypes.Name, ClaimTypes.Role);
        claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, name));


        claimsIdentity.AddClaim(new Claim(UserClaims.Email, email));

        claimsIdentity.AddClaim(new Claim(UserClaims.TenantId, organizationId.ToString()));

        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        return claimsPrincipal;
    }
}
