using System.Security.Claims;
using System.Threading.Tasks;
using InstructorIQ.Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace InstructorIQ.Core.Security
{
    public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
        public UserClaimsPrincipalFactory(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim(UserClaims.DisplayName, user.DisplayName ?? ""));

            return identity;

        }
    }
}
