using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using InstructorIQ.Core.Data.Constants;
using InstructorIQ.Core.Security;

namespace InstructorIQ.Core.Extensions
{
    public static class SecurityExtensions
    {
        public static bool IsGlobalAdministrator(this IPrincipal principal)
        {
            return principal is ClaimsPrincipal claimsPrincipal
                && claimsPrincipal.IsInRole(Role.GlobalAdministrator);
        }

        public static bool IsTenantAdministrator(this IPrincipal principal)
        {
            return principal is ClaimsPrincipal cp
                && cp.IsInRole(Role.AdministratorName);
        }


        public static string GetUserName(this IIdentity identity)
        {
            var ci = identity as ClaimsIdentity;
            return ci?.FindFirstValue(TokenConstants.Claims.Subject);
        }

        public static string GetUserId(this IIdentity identity)
        {
            var ci = identity as ClaimsIdentity;
            return ci?.FindFirstValue(TokenConstants.Claims.UserId);
        }

        public static string GetEmail(this IIdentity identity)
        {
            var ci = identity as ClaimsIdentity;
            return ci?.FindFirstValue(TokenConstants.Claims.Email);
        }

        public static string GetTenantId(this IIdentity identity)
        {
            var ci = identity as ClaimsIdentity;
            return ci?.FindFirstValue(TokenConstants.Claims.TenantId);
        }

        public static string GetTenantName(this IIdentity identity)
        {
            var ci = identity as ClaimsIdentity;
            return ci?.FindFirstValue(TokenConstants.Claims.TenantName);
        }


        public static IEnumerable<string> GetRoles(this IIdentity identity)
        {
            return FindValues(identity as ClaimsIdentity, TokenConstants.Claims.Role);
        }



        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            var claim = identity?.FindFirst(claimType);
            return claim?.Value;
        }

        public static IEnumerable<string> FindValues(this ClaimsIdentity identity, string claimType)
        {
            var claims = identity?
                .FindAll(claimType)
                .Select(c => c.Value);

            return claims;
        }
    }
}
