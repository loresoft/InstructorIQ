using System.Security.Claims;
using System.Security.Principal;
using InstructorIQ.Core.Data.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace InstructorIQ.Core.Security
{
    public class UserClaimManager
    {
        public UserClaimManager(IOptions<IdentityOptions> optionsAccessor)
        {
            Options = optionsAccessor?.Value ?? new IdentityOptions();
        }

        public IdentityOptions Options { get; }

        public bool IsGlobalAdministrator(IPrincipal principal)
        {

            return principal?.IsInRole(Role.GlobalAdministrator) ?? false;
        }

        public bool IsTenantAdministrator(IPrincipal principal)
        {
            return principal?.IsInRole(Role.AdministratorName) ?? false;
        }


        public string GetUserName(IPrincipal principal)
        {
            var claimPrincipal = principal as ClaimsPrincipal;
            return claimPrincipal?.FindFirstValue(Options.ClaimsIdentity.UserNameClaimType);
        }

        public string GetUserId(IPrincipal principal)
        {
            var claimPrincipal = principal as ClaimsPrincipal;
            return claimPrincipal?.FindFirstValue(Options.ClaimsIdentity.UserIdClaimType);
        }

        public string GetEmail(IPrincipal principal)
        {
            var claimPrincipal = principal as ClaimsPrincipal;
            return claimPrincipal?.FindFirstValue(UserClaims.Email);
        }


        public string GetDisplayName(IPrincipal principal)
        {
            var claimPrincipal = principal as ClaimsPrincipal;
            return claimPrincipal?.FindFirstValue(UserClaims.DisplayName);
        }

        public string GetTenantId(IPrincipal principal)
        {
            var claimPrincipal = principal as ClaimsPrincipal;
            return claimPrincipal?.FindFirstValue(UserClaims.TenantId);
        }
    }
}