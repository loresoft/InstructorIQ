using System;
using System.Security.Principal;

namespace InstructorIQ.Core.Security;

public interface IPrincipalTenantResolver
{
    Guid? GetTenantId(IPrincipal principal);
    Guid GetRequiredTenantId(IPrincipal principal);
}
