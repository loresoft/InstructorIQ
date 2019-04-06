using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EntityFrameworkCore.CommandQuery.Handlers;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class TenantMembershipQueryHandler : DataContextHandlerBase<InstructorIQContext, TenantMembershipQuery, TenantMembershipModel>
    {
        public TenantMembershipQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<TenantMembershipModel> Process(TenantMembershipQuery message, CancellationToken cancellationToken)
        {
            var membership = new TenantMembershipModel
            {
                TenantId = message.TenantId,
                UserName = message.UserName
            };

            var roles = await DataContext.TenantUserRoles
                .AsNoTracking()
                .Where(q => q.TenantId == message.TenantId && q.UserName == message.UserName)
                .Select(q => q.RoleName)
                .ToListAsync(cancellationToken);

            if (roles.Count == 0)
                return membership;

            membership.IsMember = roles.Contains(Data.Constants.Role.MemberName);
            membership.IsInstructor = roles.Contains(Data.Constants.Role.InstructorName);
            membership.IsAdministrator = roles.Contains(Data.Constants.Role.AdministratorName);

            return membership;
        }
    }
}
