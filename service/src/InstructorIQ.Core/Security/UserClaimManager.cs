using System;
using System.Security.Claims;
using System.Security.Principal;
using InstructorIQ.Core.Data.Constants;
using InstructorIQ.Core.Domain;
using MediatR.CommandQuery;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace InstructorIQ.Core.Security
{
    public interface IPrincipalTenantResolver
    {
        Guid? GetTenantId(IPrincipal principal);
        Guid GetRequiredTenantId(IPrincipal principal);
    }

    public class UserClaimManager : IPrincipalTenantResolver
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

        public Guid? GetUserId(IPrincipal principal)
        {
            var claimPrincipal = principal as ClaimsPrincipal;
            var userString = claimPrincipal?.FindFirstValue(Options.ClaimsIdentity.UserIdClaimType);
            if (Guid.TryParse(userString, out var userId))
                return userId;

            return null;
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

        public Guid? GetTenantId(IPrincipal principal)
        {
            var claimPrincipal = principal as ClaimsPrincipal;
            var tenantString = claimPrincipal?.FindFirstValue(UserClaims.TenantId);
            if (Guid.TryParse(tenantString, out var tenantId))
                return tenantId;

            return null;
        }

        public Guid GetRequiredTenantId(IPrincipal principal)
        {
            var claimPrincipal = principal as ClaimsPrincipal;
            var tenantString = claimPrincipal?.FindFirstValue(UserClaims.TenantId);
            if (Guid.TryParse(tenantString, out var tenantId))
                return tenantId;

            throw new DomainException(500, "Could not find tenant identifier in current user token.");
        }

        public string GetTenantName(IPrincipal principal)
        {
            var claimPrincipal = principal as ClaimsPrincipal;
            return claimPrincipal?.FindFirstValue(UserClaims.TenantName);
        }

        public string GetTenantSlug(IPrincipal principal)
        {
            var claimPrincipal = principal as ClaimsPrincipal;
            return claimPrincipal?.FindFirstValue(UserClaims.TenantSlug);
        }

    }
}