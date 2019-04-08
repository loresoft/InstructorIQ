using System;
using System.Security.Principal;
using System.Threading.Tasks;
using MediatR.CommandQuery.Definitions;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;

namespace InstructorIQ.Core.Services
{
    public class TenantResolver : ITenantResolver<Guid>
    {
        private readonly ITenant<TenantReadModel> _tenant;

        public TenantResolver(ITenant<TenantReadModel> tenant)
        {
            _tenant = tenant;
        }

        public Task<Guid> GetTenantId(IPrincipal principal)
        {
            var id = _tenant?.Value?.Id ?? Guid.Empty;
            return Task.FromResult(id);
        }
    }
}