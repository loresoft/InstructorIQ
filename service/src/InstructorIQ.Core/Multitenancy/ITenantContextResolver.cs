using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InstructorIQ.Core.Multitenancy
{
    public interface ITenantContextResolver<TTenant>
    {
        Task<TenantContext<TTenant>> ResolveAsync();

        Task<TenantContext<TTenant>> ResolveAsync(HttpContext context);
    }
}
