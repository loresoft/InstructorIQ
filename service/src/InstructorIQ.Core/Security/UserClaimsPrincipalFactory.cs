using System.Security.Claims;
using System.Threading.Tasks;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace InstructorIQ.Core.Security
{
    public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
        public UserClaimsPrincipalFactory(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> options,
            IMediator mediator)
            : base(userManager, roleManager, options)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim(UserClaims.DisplayName, user.DisplayName ?? ""));

            if (user.IsGlobalAdministrator)
                identity.AddClaim(new Claim(Options.ClaimsIdentity.RoleClaimType, Data.Constants.Role.GlobalAdministrator));

            // temp principal
            var principal = new ClaimsPrincipal(identity);

            var command = new TenantUserResolveCommand(principal, user);
            var tenantUserModel = await Mediator.Send(command);

            if (tenantUserModel == null)
                return identity;

            AddTenantClaims(tenantUserModel, identity);
            AddTenantRoles(tenantUserModel, identity);

            return identity;
        }

        private void AddTenantRoles(TenantUserModel tenantUserModel, ClaimsIdentity identity)
        {
            if (tenantUserModel.Roles == null || tenantUserModel.Roles.Count == 0)
                return;

            foreach (var role in tenantUserModel.Roles)
                identity.AddClaim(new Claim(Options.ClaimsIdentity.RoleClaimType, role));
        }

        private static void AddTenantClaims(TenantUserModel tenantUserModel, ClaimsIdentity identity)
        {
            if (tenantUserModel.Tenant == null)
                return;

            identity.AddClaim(new Claim(UserClaims.TenantId, tenantUserModel.Tenant.Id.ToString()));
            identity.AddClaim(new Claim(UserClaims.TenantName, tenantUserModel.Tenant.Name));
            identity.AddClaim(new Claim(UserClaims.TenantSlug, tenantUserModel.Tenant.Slug));
        }

    }
}
