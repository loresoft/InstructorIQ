using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Data.Queries;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Options;
using InstructorIQ.Core.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class AuthenticateCommandHandler : RequestHandlerBase<AuthenticateCommand, TokenResponse>
    {
        private readonly IOptions<PrincipalConfiguration> _principalOptions;
        private readonly IOptions<HostingConfiguration> _hostingOptions;
        private readonly InstructorIQContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticateCommandHandler(
            ILoggerFactory loggerFactory,
            IOptions<PrincipalConfiguration> principalOptions,
            IOptions<HostingConfiguration> hostingOptions,
            InstructorIQContext dataContext,
            IPasswordHasher passwordHasher) : base(loggerFactory)
        {
            _principalOptions = principalOptions;
            _hostingOptions = hostingOptions;
            _dataContext = dataContext;
            this._passwordHasher = passwordHasher;
        }

        protected override async Task<TokenResponse> Process(AuthenticateCommand message, CancellationToken cancellationToken)
        {
            var tokenRequest = message.TokenRequest;

            if (tokenRequest.GrantType == TokenConstants.GrantTypes.Password)
                return await PasswordAuthenticate(tokenRequest).ConfigureAwait(false);

            if (tokenRequest.GrantType == TokenConstants.GrantTypes.RefreshToken)
                return await RefreshAuthenticate(tokenRequest).ConfigureAwait(false);

            throw new AuthenticationException(TokenConstants.Errors.UnsupportedGrantType, "grant_type 'password' or 'refresh_token' required");
        }


        private async Task<TokenResponse> RefreshAuthenticate(TokenRequest tokenRequest)
        {
            var token = tokenRequest.RefreshToken;

            // hash refresh_token so session can't be hijacked
            var hashedToken = HashToken(token);

            var refreshToken = await _dataContext.RefreshTokens
                .GetByTokenHashedAsync(hashedToken)
                .ConfigureAwait(false);

            if (refreshToken == null)
            {
                Logger.LogWarning($"Refresh token not found; Token: {token}");
                throw new AuthenticationException(TokenConstants.Errors.InvalidRequest, "Invalid refresh token");
            }

            if (DateTimeOffset.UtcNow > refreshToken.Expires)
            {
                Logger.LogWarning($"Refresh token expired; Token: {token}");
                throw new AuthenticationException(TokenConstants.Errors.InvalidRequest, "Refresh token expired");
            }

            var organizationId = tokenRequest.OrganizationId;
            var clientId = refreshToken.ClientId;
            var userName = refreshToken.UserName;

            // create new token from refresh data
            var result = await CreateToken(organizationId, clientId, userName, null, false).ConfigureAwait(false);

            // delete refresh token to prevent reuse
            _dataContext.RefreshTokens.Remove(refreshToken);
            await _dataContext.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        private async Task<TokenResponse> PasswordAuthenticate(TokenRequest tokenRequest)
        {
            var clientId = tokenRequest.ClientId;
            var userName = tokenRequest.UserName;
            var password = tokenRequest.Password;
            var organizationId = tokenRequest.OrganizationId;

            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrEmpty(password))
                return await CreateToken(organizationId, clientId, userName, password, true).ConfigureAwait(false);

            // missing userName or password
            Logger.LogWarning($"User name or password not in form request; UserName: {userName}");
            throw new AuthenticationException(TokenConstants.Errors.InvalidGrant, "The user name or password is incorrect");
        }

        private async Task<TokenResponse> CreateToken(Guid? organizationId, string clientId, string userName, string password, bool verifyPassword)
        {
            var user = await _dataContext.Users
                .GetByEmailAddressAsync(userName)
                .ConfigureAwait(false);

            if (user == null)
            {
                Logger.LogWarning($"User name or password is incorrect; UserName: {userName}");
                throw new AuthenticationException(TokenConstants.Errors.InvalidGrant, "The user name or password is incorrect");
            }

            // validate user credentials
            await ValidateUser(user, password, verifyPassword).ConfigureAwait(false);

            organizationId = await GetOrganizationId(organizationId, user).ConfigureAwait(false);

            // create identity
            var claimsIdentity = await CreateIdentity(user, organizationId).ConfigureAwait(false);
            var accessToken = CreateAccessToken(claimsIdentity);

            // create refresh token
            var refreshToken = await CreateRefreshToken(clientId, userName, user.Id).ConfigureAwait(false);

            // update user
            user.LastLogin = DateTime.UtcNow;
            if (organizationId.HasValue)
                user.LastOrganizationId = organizationId;

            await _dataContext.SaveChangesAsync().ConfigureAwait(false);

            var response = new TokenResponse
            {
                AccessToken = accessToken,
                ExpiresIn = (int)_principalOptions.Value.TokenExpire.TotalSeconds,
                RefreshToken = refreshToken
            };

            return response;
        }

        private async Task ValidateUser(User user, string password, bool verifyPassword)
        {
            if (user.LockoutEnabled && user.LockoutEnd >= DateTimeOffset.UtcNow)
            {
                Logger.LogWarning($"User is locked out; UserName: {user.EmailAddress}");
                throw new AuthenticationException(TokenConstants.Errors.InvalidGrant, "The user is locked out");
            }

            if (!verifyPassword)
                return;

            if (_passwordHasher.VerifyPassword(user.PasswordHash, password))
            {
                await ResetAccessFailed(user).ConfigureAwait(false);
                return;
            }

            Logger.LogWarning($"User name or password is incorrect; UserName: {user.EmailAddress}");
            await IncrementAccessFailed(user).ConfigureAwait(false);

            throw new AuthenticationException(TokenConstants.Errors.InvalidGrant, "The user name or password is incorrect");
        }

        private async Task ResetAccessFailed(User user)
        {
            if (user.AccessFailedCount == 0 && user.LockoutEnabled == false)
                return;

            user.AccessFailedCount = 0;
            user.LockoutEnabled = false;
            user.LockoutEnd = null;

            await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }

        private async Task IncrementAccessFailed(User user)
        {
            user.AccessFailedCount++;

            if (user.AccessFailedCount > 5)
            {
                Logger.LogWarning($"User has been locked out; UserName: {user.EmailAddress}");

                user.AccessFailedCount = 0;
                user.LockoutEnabled = true;
                user.LockoutEnd = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(5));
            }

            await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }

        private async Task<Guid?> GetOrganizationId(Guid? id, User user)
        {
            // first try by id
            Organization organization = null;

            if (id.HasValue)
            {
                organization = await _dataContext.Organizations
                    .GetByKeyAsync(id.Value)
                    .ConfigureAwait(false);

                if (organization != null && !organization.IsDeleted)
                    return organization.Id;
            }

            // next try last organization
            if (user.LastOrganizationId.HasValue)
            {
                organization = await _dataContext.Organizations
                    .GetByKeyAsync(user.LastOrganizationId.Value)
                    .ConfigureAwait(false);

                if (organization != null && !organization.IsDeleted)
                    return organization.Id;
            }

            // finally try first membership
            var role = await _dataContext.UserRoles
                .ByUserId(user.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return role?.OrganizationId;
        }

        private async Task<ClaimsIdentity> CreateIdentity(User user, Guid? organizationId)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            //NOTE: keep token as small as possible, only add required claims
            var claimsIdentity = new ClaimsIdentity(JwtConstants.TokenType, TokenConstants.Claims.Name, TokenConstants.Claims.Role);
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Subject, user.EmailAddress));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Name, user.EmailAddress));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.UserId, user.Id.ToString()));

            //if (user.IsGlobalAdmin)
            //    claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Role, UserRoles.GlobalAdministrator));

            if (organizationId == null)
                return claimsIdentity;

            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.OrganizationId, organizationId.Value.ToString()));

            var roles = await _dataContext.UserRoles
                .Where(p => p.UserId == user.Id && p.OrganizationId == organizationId.Value)
                .Select(p => p.Role.Name)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            foreach (var role in roles)
                claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Role, role));

            return claimsIdentity;
        }

        private string CreateAccessToken(ClaimsIdentity identity)
        {
            var key = Base64UrlTextEncoder.Decode(_principalOptions.Value.AudienceSecret);
            var securityKey = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var issued = DateTime.UtcNow;
            var expires = issued.Add(_principalOptions.Value.TokenExpire);

            var token = new JwtSecurityToken(
                _hostingOptions.Value.ApplicationDomain,
                _principalOptions.Value.AudienceId,
                identity.Claims,
                issued,
                expires,
                signingCredentials);

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.WriteToken(token);

            return jwt;
        }

        private async Task<string> CreateRefreshToken(string clientId, string userName, Guid userId)
        {
            var refreshToken = Guid.NewGuid().ToString("n");
            Logger.LogDebug($"Create refresh token for {userName}");

            // hash refresh_token so session can't be hijacked
            var hashedToken = HashToken(refreshToken);
            var token = new RefreshToken
            {
                TokenHashed = hashedToken,
                ClientId = clientId,
                UserId = userId,
                UserName = userName,
                Issued = DateTimeOffset.UtcNow,
                Expires = DateTimeOffset.UtcNow.Add(_principalOptions.Value.RefreshExpire)
            };

            await _dataContext.AddAsync(token).ConfigureAwait(false);
            await _dataContext.SaveChangesAsync().ConfigureAwait(false);

            return refreshToken;
        }

        private static string HashToken(string token)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(token);
            byte[] hashBytes;

            using (var sha = new SHA512Managed())
                hashBytes = sha.ComputeHash(bytes);

            var hash = Convert.ToBase64String(hashBytes);

            return hash;
        }
    }
}
