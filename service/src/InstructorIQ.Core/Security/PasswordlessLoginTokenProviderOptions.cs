using System;
using Microsoft.AspNetCore.Identity;

namespace InstructorIQ.Core.Security
{
    public class PasswordlessLoginTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public PasswordlessLoginTokenProviderOptions()
        {
            Name = PasswordlessLoginToken.ProviderName;
            TokenLifespan = TimeSpan.FromHours(4);
        }
    }
}
