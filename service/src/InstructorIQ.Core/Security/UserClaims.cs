using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace InstructorIQ.Core.Security
{
    public  static class UserClaims
    {
        public const string Email = "email";
        public const string DisplayName = "display_name";
        public const string TenantId = "tenant_id";
        public const string TenantName = "tenant";
        public const string GlobalAdmin = "global_admin";
    }
}
