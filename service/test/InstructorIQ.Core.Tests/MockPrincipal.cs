using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using InstructorIQ.Core.Security;

namespace InstructorIQ.Core.Tests
{
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
            var claimsIdentity = new ClaimsIdentity(JwtConstants.TokenType, TokenConstants.Claims.Name, TokenConstants.Claims.Role);
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Subject, email));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Name, name));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Email, email));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.UserId, userId.ToString()));

            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.TenantId, organizationId.ToString()));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.TenantName, organizationName));

            if (isGlobalAdmin)
                claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Role, Data.Constants.Role.GlobalAdministrator));

            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Role, Data.Constants.Role.MemberName));

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
    }
}
