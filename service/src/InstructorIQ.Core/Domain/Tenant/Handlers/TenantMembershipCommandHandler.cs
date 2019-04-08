using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class TenantMembershipCommandHandler : DataContextHandlerBase<InstructorIQContext, TenantMembershipCommand, TenantMembershipModel>
    {
        public TenantMembershipCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<TenantMembershipModel> Process(TenantMembershipCommand request, CancellationToken cancellationToken)
        {
            var membership = request.Membership;
            var tenantId = membership.TenantId;
            string userName = membership.UserName;

            var roles = await DataContext.TenantUserRoles
                .Where(q => q.TenantId == membership.TenantId && q.UserName == membership.UserName)
                .ToListAsync(cancellationToken);

            // remove all to reset
            foreach (var role in roles)
                DataContext.TenantUserRoles.Remove(role);

            if (membership.IsMember)
                AddRole(tenantId, userName, Data.Constants.Role.MemberName);

            if (membership.IsInstructor)
                AddRole(tenantId, userName, Data.Constants.Role.InstructorName);

            if (membership.IsAdministrator)
                AddRole(tenantId, userName, Data.Constants.Role.AdministratorName);

            await DataContext.SaveChangesAsync(cancellationToken);

            return membership;
        }

        private void AddRole(System.Guid tenantId, string userName, string roleName)
        {
            var entity = new Data.Entities.TenantUserRole
            {
                TenantId = tenantId,
                UserName = userName,
                RoleName = roleName
            };
            DataContext.TenantUserRoles.Add(entity);
        }
    }
}
