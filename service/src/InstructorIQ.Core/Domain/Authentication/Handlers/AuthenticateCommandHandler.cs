using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Handlers;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Data.Queries;
using InstructorIQ.Core.Domain.Authentication.Commands;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Options;
using InstructorIQ.Core.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InstructorIQ.Core.Domain.Authentication.Handlers
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
            _passwordHasher = passwordHasher;
        }

        protected override async Task<TokenResponse> Process(AuthenticateCommand authenticateCommand, CancellationToken cancellationToken)
        {
            var tokenRequest = authenticateCommand.TokenRequest;

            if (tokenRequest.GrantType == TokenConstants.GrantTypes.Password)
                return await PasswordAuthenticate(authenticateCommand).ConfigureAwait(false);

            if (tokenRequest.GrantType == TokenConstants.GrantTypes.RefreshToken)
                return await RefreshAuthenticate(authenticateCommand).ConfigureAwait(false);

            throw new AuthenticationException(TokenConstants.Errors.UnsupportedGrantType, "grant_type 'password' or 'refresh_token' required");
        }


        private async Task<TokenResponse> RefreshAuthenticate(AuthenticateCommand authenticateCommand)
        {
            var tokenRequest = authenticateCommand.TokenRequest;
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

            var organizationId = tokenRequest.TenantId;
            var clientId = refreshToken.ClientId;
            var userName = refreshToken.UserName;

            // create new token from refresh data
            var result = await CreateToken(authenticateCommand.UserAgent, organizationId, clientId, userName, null, false).ConfigureAwait(false);

            // delete refresh token to prevent reuse
            _dataContext.RefreshTokens.Remove(refreshToken);
            await _dataContext.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        private async Task<TokenResponse> PasswordAuthenticate(AuthenticateCommand authenticateCommand)
        {
            var tokenRequest = authenticateCommand.TokenRequest;
            var clientId = tokenRequest.ClientId;
            var userName = tokenRequest.UserName;
            var password = tokenRequest.Password;
            var organizationId = tokenRequest.TenantId;

            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrEmpty(password))
                return await CreateToken(authenticateCommand.UserAgent, organizationId, clientId, userName, password, true).ConfigureAwait(false);

            // missing userName or password
            Logger.LogWarning($"User name or password not in form request; UserName: {userName}");
            throw new AuthenticationException(TokenConstants.Errors.InvalidGrant, "The user name or password is incorrect");
        }

        private async Task<TokenResponse> CreateToken(UserAgentModel userAgent, Guid? organizationId, string clientId, string userName, string password, bool verifyPassword)
        {
            var user = await _dataContext.Users
                .GetByEmailAddressAsync(userName)
                .ConfigureAwait(false);

            try
            {
                if (user == null)
                {
                    Logger.LogWarning($"User name or password is incorrect; UserName: {userName}");
                    throw new AuthenticationException(TokenConstants.Errors.InvalidGrant, "The user name or password is incorrect");
                }

                // validate user credentials
                await ValidateUser(user, password, verifyPassword).ConfigureAwait(false);

            }
            catch (AuthenticationException ex)
            {
                await CreateHistory(userAgent, userName, user, ex).ConfigureAwait(false);
                throw;
            }

            await CreateHistory(userAgent, userName, user).ConfigureAwait(false);

            var organization = await GetTenant(organizationId, user).ConfigureAwait(false);

            // create identity
            var claimsIdentity = await CreateIdentity(user, organization).ConfigureAwait(false);
            var accessToken = CreateAccessToken(claimsIdentity);

            // create refresh token
            var refreshToken = await CreateRefreshToken(clientId, userName, user.Id).ConfigureAwait(false);

            // update user
            user.LastLogin = DateTime.UtcNow;
            user.LastTenantId = organization?.Id;

            await _dataContext.SaveChangesAsync().ConfigureAwait(false);

            var response = new TokenResponse
            {
                AccessToken = accessToken,
                ExpiresIn = (int)_principalOptions.Value.TokenExpire.TotalSeconds,
                RefreshToken = refreshToken
            };

            return response;
        }

        private async Task CreateHistory(UserAgentModel userAgent, string userName, Data.Entities.User user, Exception exception = null)
        {
            var history = new UserLogin
            {
                UserId = user?.Id,
                EmailAddress = userName,
                Browser = userAgent.Browser,
                DeviceBrand = userAgent.DeviceBrand,
                DeviceFamily = userAgent.DeviceFamily,
                DeviceModel = userAgent.DeviceModel,
                IpAddress = userAgent.IpAddress,
                OperatingSystem = userAgent.OperatingSystem,
                UserAgent = userAgent.UserAgent,
                IsSuccessful = exception == null,
                FailureMessage = exception?.Message
            };

            await _dataContext.UserLogins.AddAsync(history).ConfigureAwait(false);
            await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }

        private async Task ValidateUser(Data.Entities.User user, string password, bool verifyPassword)
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

        private async Task ResetAccessFailed(Data.Entities.User user)
        {
            if (user.AccessFailedCount == 0 && user.LockoutEnabled == false)
                return;

            user.AccessFailedCount = 0;
            user.LockoutEnabled = false;
            user.LockoutEnd = null;

            await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }

        private async Task IncrementAccessFailed(Data.Entities.User user)
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

        private async Task<Tenant> GetTenant(Guid? id, Data.Entities.User user)
        {
            // first try by id
            Data.Entities.Tenant organization = null;

            if (id.HasValue)
            {
                organization = await _dataContext.Tenants
                    .GetByKeyAsync(id.Value)
                    .ConfigureAwait(false);

                if (organization != null && !organization.IsDeleted)
                    return organization;
            }

            // next try last tenant
            if (user.LastTenantId.HasValue)
            {
                organization = await _dataContext.Tenants
                    .GetByKeyAsync(user.LastTenantId.Value)
                    .ConfigureAwait(false);

                if (organization != null && !organization.IsDeleted)
                    return organization;
            }

            // finally try first membership
            organization = await _dataContext.UserRoles
                .ByUserId(user.Id)
                .AsNoTracking()
                .Select(o => o.Tenant)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return organization;
        }

        private async Task<ClaimsIdentity> CreateIdentity(Data.Entities.User user, Tenant tenant)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            //NOTE: keep token as small as possible, only add required claims
            var claimsIdentity = new ClaimsIdentity(JwtConstants.TokenType, TokenConstants.Claims.Name, TokenConstants.Claims.Role);
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Subject, user.EmailAddress));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Name, user.DisplayName));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Email, user.EmailAddress));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.UserId, user.Id.ToString()));

            if (user.IsGlobalAdministrator)
                claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.Role, Data.Constants.Role.GlobalAdministrator));

            if (tenant == null)
                return claimsIdentity;

            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.TenantId, tenant.Id.ToString()));
            claimsIdentity.AddClaim(new Claim(TokenConstants.Claims.TenantName, tenant.Name));

            var roles = await _dataContext.UserRoles
                .Where(p => p.UserId == user.Id && p.TenantId == tenant.Id)
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
                _hostingOptions.Value.ClientDomain,
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
