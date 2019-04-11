using Microsoft.AspNetCore.Identity;

namespace InstructorIQ.Core.Security
{
    public static class PasswordlessLoginTokenExtensions
    {
        public static IdentityBuilder AddPasswordlessLoginTokenProvider(this IdentityBuilder builder)
        {
            var userType = builder.UserType;
            var provider = typeof(PasswordlessLoginTokenProvider<>).MakeGenericType(userType);
            return builder.AddTokenProvider(PasswordlessLoginToken.ProviderName, provider);
        }
    }
}
